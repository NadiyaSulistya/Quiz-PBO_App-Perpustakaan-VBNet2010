Public Class Peminjaman
    Dim strsql As String
    Dim info As String
    Private _nomor_pinjam As System.String
    Private _tanggal_pinjam As System.DateTime
    Private _total_pinjam As System.Decimal
    Private _nomor_buku As System.String
    Private _judul As System.String
    Private _nomor_anggota As System.String
    Private _nama_anggota As System.String
    Private _kode_petugas As System.String
    Private _nama_petugas As System.String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property nomor_pinjam()
        Get
            Return _nomor_pinjam
        End Get
        Set(ByVal value)
            _nomor_pinjam = value
        End Set
    End Property
    Public Property tanggal_pinjam()
        Get
            Return _tanggal_pinjam
        End Get
        Set(ByVal value)
            _tanggal_pinjam = value
        End Set
    End Property
    Public Property total_pinjam()
        Get
            Return _total_pinjam
        End Get
        Set(ByVal value)
            _total_pinjam = value
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
        If (PEMINJAMAN_baru = True) Then
            strsql = "Insert into PEMINJAMAN(nomor_pinjam,tanggal_pinjam,total_pinjam,nomor_buku,judul,nomor_anggota,nama_anggota,kode_petugas,nama_petugas) values ('" & _nomor_pinjam & "','" & _tanggal_pinjam & "','" & _total_pinjam & "','" & _nomor_buku & "','" & _judul & "','" & _nomor_anggota & "','" & _nama_anggota & "','" & _kode_petugas & "','" & _nama_petugas & "')"
            info = "INSERT"
        Else
            strsql = "update PEMINJAMAN set nomor_pinjam='" & _nomor_pinjam & "', tanggal_pinjam='" & _tanggal_pinjam & "', total_pinjam='" & _total_pinjam & "', nomor_buku='" & _nomor_buku & "', judul='" & _judul & "', nomor_anggota='" & _nomor_anggota & "', nama_anggota='" & _nama_anggota & "', kode_petugas='" & _kode_petugas & "', nama_petugas='" & _nama_petugas & "' where TANGGAL_PINJAM='" & _TANGGAL_PINJAM & "'"
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
    Public Sub CariPEMINJAMAN(ByVal sNOMOR_PINJAM As String)
        DBConnect()
        strsql = "SELECT * FROM PEMINJAMAN WHERE NOMOR_PINJAM='" & sNOMOR_PINJAM & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            PEMINJAMAN_baru = False
            DR.Read()
            nomor_pinjam = Convert.ToString((DR("nomor_pinjam")))
            tanggal_pinjam = Convert.ToString((DR("tanggal_pinjam")))
            total_pinjam = Convert.ToString((DR("total_pinjam")))
            nomor_buku = Convert.ToString((DR("nomor_buku")))
            judul = Convert.ToString((DR("judul")))
            nomor_anggota = Convert.ToString((DR("nomor_anggota")))
            nama_anggota = Convert.ToString((DR("nama_anggota")))
            kode_petugas = Convert.ToString((DR("kode_petugas")))
            nama_petugas = Convert.ToString((DR("nama_petugas")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            PEMINJAMAN_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sNOMOR_PINJAM As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM PEMINJAMAN WHERE NOMOR_PINJAM='" & sNOMOR_PINJAM & "'"
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
            strsql = "SELECT * FROM PEMINJAMAN"
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
