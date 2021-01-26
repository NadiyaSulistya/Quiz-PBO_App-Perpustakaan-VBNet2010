Public Class Anggota
    Dim strsql As String
    Dim info As String
    Private _nomor_anggota As System.String
    Private _nama_anggota As System.String
    Private _alamat_anggota As System.String
    Private _telepon_anggota As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nomor_anggota()
        Get
            Return _nomor_anggota
        End Get
        Set(ByVal value)
            _nomor_anggota = value
        End Set
    End Property
    Public Property nama_anggota()
        Get
            Return _nama_anggota
        End Get
        Set(ByVal value)
            _nama_anggota = value
        End Set
    End Property
    Public Property alamat_anggota()
        Get
            Return _alamat_anggota
        End Get
        Set(ByVal value)
            _alamat_anggota = value
        End Set
    End Property
    Public Property telepon_anggota()
        Get
            Return _telepon_anggota
        End Get
        Set(ByVal value)
            _telepon_anggota = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (ANGGOTA_baru = True) Then
            strsql = "Insert into ANGGOTA(nomor_anggota,nama_anggota,alamat_anggota,telepon_anggota) values ('" & _nomor_anggota & "','" & _nama_anggota & "','" & _alamat_anggota & "','" & _telepon_anggota & "')"
            info = "INSERT"
        Else
            strsql = "update ANGGOTA set nomor_anggota='" & _nomor_anggota & "', nama_anggota='" & _nama_anggota & "', alamat_anggota='" & _alamat_anggota & "', telepon_anggota='" & _telepon_anggota & "' where NAMA_ANGGOTA='" & _NAMA_ANGGOTA & "'"
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
    Public Sub CariANGGOTA(ByVal sNOMOR_ANGGOTA As String)
        DBConnect()
        strsql = "SELECT * FROM ANGGOTA WHERE NOMOR_ANGGOTA='" & sNOMOR_ANGGOTA & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            ANGGOTA_baru = False
            DR.Read()
            nomor_anggota = Convert.ToString((DR("nomor_anggota")))
            nama_anggota = Convert.ToString((DR("nama_anggota")))
            alamat_anggota = Convert.ToString((DR("alamat_anggota")))
            telepon_anggota = Convert.ToString((DR("telepon_anggota")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            ANGGOTA_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sNOMOR_ANGGOTA As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM ANGGOTA WHERE NOMOR_ANGGOTA='" & sNOMOR_ANGGOTA & "'"
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
            strsql = "SELECT * FROM ANGGOTA"
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
