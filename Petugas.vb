Public Class Petugas
    Dim strsql As String
    Dim info As String
    Private _kode_petugas As System.String
    Private _nama_petugas As System.String
    Private _password_petugas As System.String
    Private _status_petugas As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property kode_petugas()
        Get
            Return _kode_petugas
        End Get
        Set(ByVal value)
            _kode_petugas = value
        End Set
    End Property
    Public Property nama_petugas()
        Get
            Return _nama_petugas
        End Get
        Set(ByVal value)
            _nama_petugas = value
        End Set
    End Property
    Public Property password_petugas()
        Get
            Return _password_petugas
        End Get
        Set(ByVal value)
            _password_petugas = value
        End Set
    End Property
    Public Property status_petugas()
        Get
            Return _status_petugas
        End Get
        Set(ByVal value)
            _status_petugas = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (PETUGAS_baru = True) Then
            strsql = "Insert into PETUGAS(kode_petugas,nama_petugas,password_petugas,status_petugas) values ('" & _kode_petugas & "','" & _nama_petugas & "','" & _password_petugas & "','" & _status_petugas & "')"
            info = "INSERT"
        Else
            strsql = "update PETUGAS set kode_petugas='" & _kode_petugas & "', nama_petugas='" & _nama_petugas & "', password_petugas='" & _password_petugas & "', status_petugas='" & _status_petugas & "' where NAMA_PETUGAS='" & _NAMA_PETUGAS & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else
            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else
            End If
        End Try
        DBDisconnect()
    End Sub
    Public Sub CariPETUGAS(ByVal sKODE_PETUGAS As String)
        DBConnect()
        strsql = "SELECT * FROM PETUGAS WHERE KODE_PETUGAS='" & sKODE_PETUGAS & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            PETUGAS_baru = False
            DR.Read()
            kode_petugas = Convert.ToString((DR("kode_petugas")))
            nama_petugas = Convert.ToString((DR("nama_petugas")))
            password_petugas = Convert.ToString((DR("password_petugas")))
            status_petugas = Convert.ToString((DR("status_petugas")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            PETUGAS_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sKODE_PETUGAS As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM PETUGAS WHERE KODE_PETUGAS='" & sKODE_PETUGAS & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        DBDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM PETUGAS"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
