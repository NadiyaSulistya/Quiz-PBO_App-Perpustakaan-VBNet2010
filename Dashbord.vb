Public Class Dashbord

    Private Sub btnAnggota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnggota.Click
        If (menu_Anggota = False) Then
            BikinMenu(cldAnggota, TabControl1, "Anggota")
            menu_Anggota = True
        Else
            x = getTabIndex(TabControl1, "Anggota")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnPetugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPetugas.Click
        If (menu_Petugas = False) Then
            BikinMenu(cldPetugas, TabControl1, "Petugas")
            menu_Petugas = True
        Else
            x = getTabIndex(TabControl1, "Petugas")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnBuku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuku.Click
        If (menu_Buku = False) Then
            BikinMenu(cldBuku, TabControl1, "Buku")
            menu_Buku = True
        Else
            x = getTabIndex(TabControl1, "Buku")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnPeminjaman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeminjaman.Click
        If (menu_Peminjaman = False) Then
            BikinMenu(cldPeminjaman, TabControl1, "Peminjaman")
            menu_Peminjaman = True
        Else
            x = getTabIndex(TabControl1, "Peminjaman")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub btnPengembalian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPengembalian.Click
        If (menu_Pengembalian = False) Then
            BikinMenu(cldPeminjaman, TabControl1, "Pengembalian")
            menu_Pengembalian = True
        Else
            x = getTabIndex(TabControl1, "Pengembalian")
            TabControl1.SelectedTabIndex = x
        End If
    End Sub

    Private Sub TabControl1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles TabControl1.ControlAdded
        TabControl1.SelectedTabIndex = TotalTab - 1
    End Sub

    Private Sub TabControl1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabControl1.TabItemClose
        Dim itemToRemove As DevComponents.DotNetBar.TabItem = TabControl1.SelectedTab
        If (TotalTab > 2) Then
            TotalTab = TotalTab - 1
        Else
            TotalTab = 0
        End If


        TabControl1.Tabs.Remove(itemToRemove)
        TabControl1.Controls.Remove(itemToRemove.AttachedControl)
        TabControl1.RecalcLayout()


        If (itemToRemove.ToString = "Anggota") Then
            menu_Anggota = False
        ElseIf (itemToRemove.ToString = "Petugas") Then
            menu_Petugas = False
        ElseIf (itemToRemove.ToString = "Buku") Then
            menu_Buku = False
        Else

        End If
    End Sub

    Private Sub TabControl1_TabItemOpen(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.TabItemOpen
        If (TotalTab = 0) Then
            TotalTab = TotalTab + 2
        Else
            TotalTab = TotalTab + 1
        End If
    End Sub
End Class