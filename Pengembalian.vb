Public Class Pengembalian
    Dim strsql As String
    Dim info As String
    Private _nomor_kembali As System.String
    Private _tanggal_kembali As System.DateTime
    Private _nomor_buku As System.String
    Private _judul As System.String
    Private _total_kembali As System.Decimal
    Private _denda As System.Decimal
    Private _nomor_anggota As System.String
    Private _nama_anggota As System.String
    Private _kode_petugas As System.String
    Private _nama_petugas As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nomor_kembali()
        Get
            Return _nomor_kembali
        End Get
        Set(ByVal value)
            _nomor_kembali = value
        End Set
    End Property
    Public Property tanggal_kembali()
        Get
            Return _tanggal_kembali
        End Get
        Set(ByVal value)
            _tanggal_kembali = value
        End Set
    End Property
    Public Property nomor_buku()
        Get
            Return _nomor_buku
        End Get
        Set(ByVal value)
            _nomor_buku = value
        End Set
    End Property
    Public Property judul()
        Get
            Return _judul
        End Get
        Set(ByVal value)
            _judul = value
        End Set
    End Property
    Public Property total_kembali()
        Get
            Return _total_kembali
        End Get
        Set(ByVal value)
            _total_kembali = value
        End Set
    End Property
    Public Property denda()
        Get
            Return _denda
        End Get
        Set(ByVal value)
            _denda = value
        End Set
    End Property
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
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (PENGEMBALIAN_baru = True) Then
            strsql = "Insert into PENGEMBALIAN(nomor_kembali,tanggal_kembali,nomor_buku,judul,total_kembali,denda,nomor_anggota,nama_anggota,kode_petugas,nama_petugas) values ('" & _nomor_kembali & "','" & _tanggal_kembali & "','" & _nomor_buku & "','" & _judul & "','" & _total_kembali & "','" & _denda & "','" & _nomor_anggota & "','" & _nama_anggota & "','" & _kode_petugas & "','" & _nama_petugas & "')"
            info = "INSERT"
        Else
            strsql = "update PENGEMBALIAN set nomor_kembali='" & _nomor_kembali & "', tanggal_kembali='" & _tanggal_kembali & "', nomor_buku='" & _nomor_buku & "', judul='" & _judul & "', total_kembali='" & _total_kembali & "', denda='" & _denda & "', nomor_anggota='" & _nomor_anggota & "', nama_anggota='" & _nama_anggota & "', kode_petugas='" & _kode_petugas & "', nama_petugas='" & _nama_petugas & "' where TANGGAL_KEMBALI='" & _TANGGAL_KEMBALI & "'"
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
    Public Sub CariPENGEMBALIAN(ByVal sNOMOR_KEMBALI As String)
        DBConnect()
        strsql = "SELECT * FROM PENGEMBALIAN WHERE NOMOR_KEMBALI='" & sNOMOR_KEMBALI & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            PENGEMBALIAN_baru = False
            DR.Read()
            nomor_kembali = Convert.ToString((DR("nomor_kembali")))
            tanggal_kembali = Convert.ToString((DR("tanggal_kembali")))
            nomor_buku = Convert.ToString((DR("nomor_buku")))
            judul = Convert.ToString((DR("judul")))
            total_kembali = Convert.ToString((DR("total_kembali")))
            denda = Convert.ToString((DR("denda")))
            nomor_anggota = Convert.ToString((DR("nomor_anggota")))
            nama_anggota = Convert.ToString((DR("nama_anggota")))
            kode_petugas = Convert.ToString((DR("kode_petugas")))
            nama_petugas = Convert.ToString((DR("nama_petugas")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            PENGEMBALIAN_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sNOMOR_KEMBALI As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM PENGEMBALIAN WHERE NOMOR_KEMBALI='" & sNOMOR_KEMBALI & "'"
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
            strsql = "SELECT * FROM PENGEMBALIAN"
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
