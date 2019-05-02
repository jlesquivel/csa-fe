'' #######################  VER EJEMPLO DE COMO USAR AL FINAL
Imports System
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Imports System.Management

Public NotInheritable Class NetworkInformation

    Public Enum JoinStatus
        Unknown = 0
        UnJoined = 1
        Workgroup = 2
        Domain = 3
    End Enum

    <DllImport("netapi32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Shared Function NetGetJoinInformation( _
        ByVal computerName As String, _
        ByRef buffer As IntPtr, _
        ByRef status As JoinStatus) As Integer
    End Function

    <DllImport("netapi32.dll", SetLastError:=True)> _
    Shared Function NetApiBufferFree(ByVal buffer As IntPtr) As Integer
    End Function

    Private Shared _local As New NetworkInformation()
    Private _computerName As String
    Private _domainName As String
    Private _status As JoinStatus = JoinStatus.Unknown

    Public Sub New(ByVal computerName As String)
        If computerName Is Nothing OrElse 0 = computerName.Length Then
            Throw New ArgumentNullException("computerName")
        End If

        _computerName = computerName
        LoadInformation()
    End Sub

    Private Sub New()
        LoadInformation()
    End Sub

    Public Shared ReadOnly Property LocalComputer As NetworkInformation
        Get
            Return _local
        End Get
    End Property

    Public ReadOnly Property ComputerName As String
        Get
            If _computerName Is Nothing Then Return "(local)"
            Return _computerName
        End Get
    End Property

    Public ReadOnly Property DomainName As String
        Get
            Return _domainName
        End Get
    End Property

    Public ReadOnly Property Status As JoinStatus
        Get
            Return _status
        End Get
    End Property

    Private Sub LoadInformation()
        Dim pBuffer As IntPtr = IntPtr.Zero
        Dim status As JoinStatus

        Try
            Dim result As Integer = NetGetJoinInformation(_computerName, pBuffer, status)
            If 0 <> result Then Throw New Win32Exception()

            _status = status
            _domainName = Marshal.PtrToStringUni(pBuffer)

        Finally
            If Not IntPtr.Zero.Equals(pBuffer) Then
                NetApiBufferFree(pBuffer)
            End If
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Select Case _status
            Case JoinStatus.Domain
                Return ComputerName & " es miembro del dominio " & DomainName
            Case JoinStatus.Workgroup
                Return ComputerName & " es miembro del workgroup " & DomainName
            Case JoinStatus.UnJoined
                Return ComputerName & " es una computadora autonoma"
            Case Else
                Return "Imposibe determinar el estatus de " & ComputerName
        End Select
    End Function



End Class

''  EJEMPLO DE  COMO USAR LA CLASE
'' 
'     
'Dim info As NetworkInformation = NetworkInformation.LocalComputer

'        ListBox1.Items.Add(info.ToString())

'        If info.Status = NetworkInformation.JoinStatus.Workgroup Then
'            ListBox1.Items.Add("You are part of a workgroup :" & info.DomainName)

'        ElseIf info.Status = NetworkInformation.JoinStatus.Domain Then
'            ListBox1.Items.Add("You are part of a domain " & info.DomainName)

'        Else
'            ListBox1.Items.Add("You are not in a domain or workgroup")
'        End If
''  OTRO EJEMPLO DE COMO USAR system information
''
'       ListBox1.Items.Add("ComputerName : " + SystemInformation.ComputerName)
'        ListBox1.Items.Add("Network : " + SystemInformation.Network.ToString())
'        ListBox1.Items.Add("UserDomainName : " + SystemInformation.UserDomainName)
'        ListBox1.Items.Add("UserName : " + SystemInformation.UserName)
