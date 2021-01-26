Public Class Buku
    Dim strsql As String
    Dim info As String
    Private _nomor_buku As System.String
    Private _judul As System.String
    Private _genre As System.String
    Private _pengarang As System.String
    Private _penerbit As System.String
    Private _stok As System.Decimal
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
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
    Public Property genre()
        Get
            Return _genre
        End Get
        Set(ByVal value)
            _genre = value
        End Set
    End Property
    Public Property pengarang()
        Get
            Return _pengarang
        End Get
        Set(ByVal value)
            _pengarang = value
        End Set
    End Property
    Public Property penerbit()
        Get
            Return _penerbit
        End Get
        Set(ByVal value)
            _penerbit = value
        End Set
    End Property
    Public Property stok()
        Get
            Return _stok
        End Get
        Set(ByVal value)
            _stok = value
        End Set
    End Property
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (BUKU_baru = True) Then
            strsql = "Insert into BUKU(nomor_buku,judul,genre,pengarang,penerbit,stok) values ('" & _nomor_buku & "','" & _judul & "','" & _genre & "','" & _pengarang & "','" & _penerbit & "','" & _stok & "')"
            info = "INSERT"
        Else
            strsql = "update BUKU set nomor_buku='" & _nomor_buku & "', judul='" & _judul & "', genre='" & _genre & "', pengarang='" & _pengarang & "', penerbit='" & _penerbit & "', stok='" & _stok & "' where JUDUL='" & _JUDUL & "'"
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
    Public Sub CariBUKU(ByVal sNOMOR_BUKU As String)
        DBConnect()
        strsql = "SELECT * FROM BUKU WHERE NOMOR_BUKU='" & sNOMOR_BUKU & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            BUKU_baru = False
            DR.Read()
            nomor_buku = Convert.ToString((DR("nomor_buku")))
            judul = Convert.ToString((DR("judul")))
            genre = Convert.ToString((DR("genre")))
            pengarang = Convert.ToString((DR("pengarang")))
            penerbit = Convert.ToString((DR("penerbit")))
            stok = Convert.ToString((DR("stok")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            BUKU_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal sNOMOR_BUKU As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM BUKU WHERE NOMOR_BUKU='" & sNOMOR_BUKU & "'"
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
            strsql = "SELECT * FROM BUKU"
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
