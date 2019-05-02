Imports System.Threading

Public Class Fibonacci
    Private _doneEvent As ManualResetEvent

    Public Sub New(n As Integer, doneEvent As ManualResetEvent)
        Me.N = n
        _doneEvent = doneEvent
    End Sub

    Public ReadOnly Property N As Integer
    Public Property FibOfN As Integer

    Public Sub ThreadPoolCallback(threadContext As Object)
        Dim threadIndex As Integer = CType(threadContext, Integer)
        Console.WriteLine($"Thread {threadIndex} started...")
        FibOfN = Calculate(N)
        Console.WriteLine($"Thread {threadIndex} result calculated...")
        _doneEvent.Set()
    End Sub

    Public Function Calculate(n As Integer) As Integer
        If (n <= 1) Then
            Return n
        End If
        Return Calculate(n - 1) + Calculate(n - 2)
    End Function
End Class

Public Class ThreadPoolExample
    <MTAThread>
    Public Shared Sub Main()
        Const FibonacciCalculations As Integer = 5

        Dim doneEvents(FibonacciCalculations - 1) As ManualResetEvent
        Dim fibArray(FibonacciCalculations - 1) As Fibonacci
        Dim rand As Random = New Random()

        Console.WriteLine($"Launching {FibonacciCalculations} tasks...")

        For i As Integer = 0 To FibonacciCalculations - 1
            doneEvents(i) = New ManualResetEvent(False)
            Dim f As Fibonacci = New Fibonacci(rand.Next(35, 44), doneEvents(i))
            fibArray(i) = f
            ThreadPool.QueueUserWorkItem(AddressOf f.ThreadPoolCallback, i)
        Next

        WaitHandle.WaitAll(doneEvents)
        Console.WriteLine("All calculations are complete.")

        For i As Integer = 0 To FibonacciCalculations - 1
            Dim f As Fibonacci = fibArray(i)
            Console.WriteLine($"Fibonacci({f.N}) = {f.FibOfN}")
        Next

        Console.ReadKey()
    End Sub
End Class