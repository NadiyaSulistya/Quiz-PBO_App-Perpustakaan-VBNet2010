Imports System.Data.OracleClient
Imports System.Security.Cryptography
Imports DevComponents.DotNetBar

Module Mymod
    Public mycommand As New System.Data.OracleClient.OracleCommand
    Public myadapter As New System.Data.OracleClient.OracleDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.OracleClient.OracleDataReader
    Public SQL As String
    Public conn As New System.Data.OracleClient.OracleConnection
    Public cn As New Connection

    'Tabel Buku
    '-------------------------------
    Public Buku_baru As Boolean
    Public oBuku As New frmBuku
    '--------------------------------

    'Tabel Anggota
    '-------------------------------
    Public Anggota_baru As Boolean
    Public oAnggota As New frmAnggota
    '--------------------------------

    'Tabel Petugas
    '-------------------------------
    Public Petugas_baru As Boolean
    Public oPetugas As New frmPetugas
    '--------------------------------

    'Tabel Peminjaman
    '-------------------------------
    Public Peminjaman_baru As Boolean
    Public oPeminjaman As New frmPeminjaman
    '--------------------------------

    'Tabel Pengembalian
    '-------------------------------
    Public Pengembalian_baru As Boolean
    Public oPengembalian As New frmPengembalian
    '--------------------------------

    'Tabel User
    '--------------------------------
    Public user_baru As Boolean
    Public oUser As New User
    '--------------------------------

    Public login_valid As Boolean

    Public Sub DBConnect()
        cn.DataSource = "xe"
        cn.UserID = "Nadiya"
        cn.Password = "123"
        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub

    Public Function getMD5Hash(ByVal strToHash As String) As String

        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Public cldBuku As New frmBuku()
    Public cldAnggota As New frmAnggota()
    Public cldPetugas As New frmPetugas()
    Public cldPeminjaman As New frmPeminjaman()
    Public cldPengembalian As New frmPengembalian()

    Public menu_Buku As Boolean
    Public menu_Anggota As Boolean
    Public menu_Petugas As Boolean
    Public menu_Peminjaman As Boolean
    Public menu_Pengembalian As Boolean

    Public TotalTab As Integer = 0
    Public x As Integer

    Public Function getTabIndex(ByVal mytab As TabControl, ByVal sCari As String)
        Dim i As Integer
        For i = 0 To TotalTab - 1
            If (mytab.Tabs(i).Text = sCari) Then

                Exit For
            End If
        Next
        getTabIndex = i
    End Function

    Public Sub BikinMenu(ByVal Child As Form, ByVal mytab As TabControl, ByVal sTitle As String)

        Dim newTab As DevComponents.DotNetBar.TabItem = mytab.CreateTab(sTitle)
        Dim panel As DevComponents.DotNetBar.TabControlPanel = DirectCast(newTab.AttachedControl, Panel)


        Child.TopLevel = False
        Child.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Child.Dock = DockStyle.Fill
        Child.Show()
        panel.Controls.Add(Child)
    End Sub
End Module