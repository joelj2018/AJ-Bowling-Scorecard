
Imports System.Runtime.InteropServices

Public Class scorecard

    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const APPCOMMAND_VOLUME_UP As Integer = &HA0000
    Private Const APPCOMMAND_VOLUME_DOWN As Integer = &H90000
    Private Const WM_APPCOMMAND As Integer = &H319

    Dim framevalues1(10) As Integer
    Dim framevalues2(10) As Integer
    Dim framevalues3(10) As Integer
    Dim framevalues4(10) As Integer

    Dim spares1 As New List(Of Integer)()
    Dim strikes1 As New List(Of Integer)()
    Dim spares2 As New List(Of Integer)()
    Dim strikes2 As New List(Of Integer)()
    Dim spares3 As New List(Of Integer)()
    Dim strikes3 As New List(Of Integer)()
    Dim spares4 As New List(Of Integer)()
    Dim strikes4 As New List(Of Integer)()

    Dim First As Integer
    Dim Second As Integer
    Dim Third As Integer
    Dim Fourth As Integer
    Dim Max As Integer

    Private Sub Strike(frame As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        If n = 1 Then
            If spares1.Contains(frame - 1) Then
                framevalues1(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    framevalues1(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes1.Add(frame)
        ElseIf n = 2 Then
            If spares2.Contains(frame - 1) Then
                framevalues2(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    framevalues2(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes2.Add(frame)
        ElseIf n = 3 Then
            If spares3.Contains(frame - 1) Then
                framevalues3(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    framevalues3(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes3.Add(frame)
        ElseIf n = 4 Then
            If spares4.Contains(frame - 1) Then
                framevalues4(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    framevalues4(frame - 3) = 30
                    XXbox.Text = findTotal(frame - 2, n)
                End If
            End If
            strikes4.Add(frame)
        Else

        End If
    End Sub

    Private Sub Spare(frame As Integer, v1 As Integer, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)

        If n = 1 Then
            If spares1.Contains(frame - 1) Then
                framevalues1(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    framevalues1(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues1(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares1.Add(frame)
        ElseIf n = 2 Then
            If spares2.Contains(frame - 1) Then
                framevalues2(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    framevalues2(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues2(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares2.Add(frame)
        ElseIf n = 3 Then
            If spares3.Contains(frame - 1) Then
                framevalues3(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    framevalues3(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues3(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares3.Add(frame)
        ElseIf n = 4 Then
            If spares4.Contains(frame - 1) Then
                framevalues4(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    framevalues4(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues4(frame - 2) = 20
                prevbox.Text = findTotal(frame - 1, n)
            End If
            spares4.Add(frame)
        Else
        End If
    End Sub

    Private Sub OpenFrame(frame As Integer, v1 As Integer, v2 As Integer,
                          ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, n As Integer)
        If n = 1 Then
            If spares1.Contains(frame - 1) Then
                framevalues1(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes1.Contains(frame - 1) Then
                If strikes1.Contains(frame - 2) Then
                    framevalues1(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues1(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues1(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        ElseIf n = 2 Then
            If spares2.Contains(frame - 1) Then
                framevalues2(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes2.Contains(frame - 1) Then
                If strikes2.Contains(frame - 2) Then
                    framevalues2(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues2(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues2(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        ElseIf n = 3 Then
            If spares3.Contains(frame - 1) Then
                framevalues3(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes3.Contains(frame - 1) Then
                If strikes3.Contains(frame - 2) Then
                    framevalues3(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues3(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues3(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        ElseIf n = 4 Then
            If spares4.Contains(frame - 1) Then
                framevalues4(frame - 2) = 10 + v1
                prevbox.Text = findTotal(frame - 1, n)
            ElseIf strikes4.Contains(frame - 1) Then
                If strikes4.Contains(frame - 2) Then
                    framevalues4(frame - 3) = 20 + v1
                    XXbox.Text = findTotal(frame - 2, n)
                End If
                framevalues4(frame - 2) = 10 + v1 + v2
                prevbox.Text = findTotal(frame - 1, n)
            End If
            framevalues4(frame - 1) = v1 + v2
            currentbox.Text = findTotal(frame, n)
        Else
        End If

    End Sub

    Private Sub TenthFrame(v1 As Integer, v2 As Integer, v3 As Integer,
                           ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                           ByRef XXbox As TextBox, n As Integer)
        If (v1 + v2 < 10) Then
            OpenFrame(10, v1, v2, currentbox, prevbox, XXbox, n)
        ElseIf (v1 + v2 = 10) Then
            Spare(10, v1, prevbox, XXbox, n)
            If n = 1 Then
                framevalues1(9) = 10 + v3
            ElseIf n = 2 Then
                framevalues2(9) = 10 + v3
            ElseIf n = 3 Then
                framevalues3(9) = 10 + v3
            ElseIf n = 4 Then
                framevalues4(9) = 10 + v3
            Else

            End If
            currentbox.Text = findTotal(10, n)

        Else
            Strike(10, prevbox, XXbox, n)
            Strike(11, currentbox, prevbox, n)
            If n = 1 Then
                framevalues1(9) = 10 + v2 + v3
            ElseIf n = 2 Then
                framevalues2(9) = 10 + v2 + v3
            ElseIf n = 3 Then
                framevalues3(9) = 10 + v2 + v3
            ElseIf n = 4 Then
                framevalues4(9) = 10 + v2 + v3
            Else
            End If
            currentbox.Text = findTotal(10, n)
        End If
    End Sub

    Private Function findTotal(frame As Integer, n As Integer)
        Dim total As Integer
        If n = 1 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues1(i)
            Next
        ElseIf n = 2 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues2(i)
            Next
        ElseIf n = 3 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues3(i)
            Next
        ElseIf n = 4 Then
            For i As Integer = 0 To (frame - 1) Step 1
                total += framevalues4(i)
            Next
        Else

        End If
        Return total
    End Function


    Private Sub Calculate(ByRef currentbox As TextBox, ByRef prevbox As TextBox,
                          ByRef XXbox As TextBox, frame As Integer, v1 As Integer,
                          v2 As Integer, v3 As Integer, n As Integer)
        If (frame < 10) Then
            If (v1 + v2) < 10 Then
                If n = 1 Then
                    If strikes1.Contains(frame) Then
                        strikes1.Remove(frame)
                    ElseIf spares1.Contains(frame) Then
                        spares1.Remove(frame)
                    End If
                ElseIf n = 2 Then
                    If strikes2.Contains(frame) Then
                        strikes2.Remove(frame)
                    ElseIf spares2.Contains(frame) Then
                        spares2.Remove(frame)
                    End If
                ElseIf n = 3 Then
                    If strikes3.Contains(frame) Then
                        strikes3.Remove(frame)
                    ElseIf spares3.Contains(frame) Then
                        spares3.Remove(frame)
                    End If
                ElseIf n = 4 Then
                    If strikes4.Contains(frame) Then
                        strikes4.Remove(frame)
                    ElseIf spares4.Contains(frame) Then
                        spares4.Remove(frame)
                    End If
                Else

                End If
                OpenFrame(frame, v1, v2, currentbox, prevbox, XXbox, n)
            ElseIf v1 = 10 Then
                If n = 1 Then
                    If spares1.Contains(frame) Then
                        spares1.Remove(frame)
                    End If
                    framevalues1(frame - 1) = 0
                ElseIf n = 2 Then
                    If spares2.Contains(frame) Then
                        spares2.Remove(frame)
                    End If
                    framevalues2(frame - 1) = 0
                ElseIf n = 3 Then
                    If spares3.Contains(frame) Then
                        spares3.Remove(frame)
                    End If
                    framevalues3(frame - 1) = 0
                ElseIf n = 4 Then
                    If spares4.Contains(frame) Then
                        spares4.Remove(frame)
                    End If
                    framevalues4(frame - 1) = 0
                Else

                End If
                Strike(frame, prevbox, XXbox, n)
                currentbox.Text = ""
            Else
                If n = 1 Then
                    If strikes1.Contains(frame) Then
                        strikes1.Remove(frame)
                    End If
                    framevalues1(frame - 1) = 0
                ElseIf n = 2 Then
                    If strikes2.Contains(frame) Then
                        strikes2.Remove(frame)
                    End If
                    framevalues2(frame - 1) = 0
                ElseIf n = 3 Then
                    If strikes3.Contains(frame) Then
                        strikes3.Remove(frame)
                    End If
                    framevalues3(frame - 1) = 0
                ElseIf n = 4 Then
                    If strikes4.Contains(frame) Then
                        strikes4.Remove(frame)
                    End If
                    framevalues4(frame - 1) = 0
                Else

                End If
                Spare(frame, v1, prevbox, XXbox, n)
                currentbox.Text = ""
            End If
        Else
            TenthFrame(v1, v2, v3, currentbox, prevbox, XXbox, n)
        End If
    End Sub




    Private Sub shot1Calculator(ByRef currentBox As TextBox, ByRef prevBox As TextBox, ByRef XXBox As TextBox,
                                ByRef comboN1 As ComboBox, ByRef comboN2 As ComboBox, ByRef comboN11 As ComboBox,
                                n As Integer, frame As Integer)
        Dim value As String
        value = comboN1.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                Calculate(currentBox, prevBox, XXBox, frame, 10, 0, 0, n)
                comboN2.Items.Clear()
                comboN2.Enabled = False
                comboN11.Enabled = True
            Else
                comboN2.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    comboN2.Items.Add(i)
                Next
                comboN2.Items.Add("/")
                comboN2.Enabled = True
            End If
        End If
    End Sub

    Private Sub shot2Calculator(ByRef currentBox As TextBox, ByRef prevBox As TextBox, ByRef XXBox As TextBox,
                                ByRef comboN1 As ComboBox, ByRef comboN2 As ComboBox, ByRef comboN11 As ComboBox,
                                n As Integer, frame As Integer)
        Dim v1 As Integer
        Dim value2 As String
        Dim v2 As Integer
        v1 = comboN1.SelectedItem
        value2 = comboN2.SelectedItem
        If Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(v1) Then
            If value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If
            Calculate(currentBox, prevBox, XXBox, frame, v1, v2, 0, n)
            comboN11.Enabled = True
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox111.SelectedIndexChanged
        shot1Calculator(TextBox11, TextBox11, TextBox11, ComboBox111, ComboBox112, ComboBox121, 1, 1)
        ComboBox111.Enabled = False
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox112.SelectedIndexChanged
        shot2Calculator(TextBox11, TextBox11, TextBox11, ComboBox111, ComboBox112, ComboBox121, 1, 1)
        ComboBox112.Enabled = False
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox121.SelectedIndexChanged
        shot1Calculator(TextBox12, TextBox11, TextBox11, ComboBox121, ComboBox122, ComboBox131, 1, 2)
        ComboBox121.Enabled = False
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox122.SelectedIndexChanged
        shot2Calculator(TextBox12, TextBox11, TextBox11, ComboBox121, ComboBox122, ComboBox131, 1, 2)
        ComboBox122.Enabled = False
    End Sub

    Private Sub ComboBox131_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox131.SelectedIndexChanged
        shot1Calculator(TextBox13, TextBox12, TextBox11, ComboBox131, ComboBox132, ComboBox141, 1, 3)
        ComboBox131.Enabled = False
    End Sub

    Private Sub ComboBox132_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox132.SelectedIndexChanged
        shot2Calculator(TextBox13, TextBox12, TextBox11, ComboBox131, ComboBox132, ComboBox141, 1, 3)
        ComboBox132.Enabled = False
    End Sub

    Private Sub ComboBox141_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox141.SelectedIndexChanged
        shot1Calculator(TextBox14, TextBox13, TextBox12, ComboBox141, ComboBox142, ComboBox151, 1, 4)
        ComboBox141.Enabled = False
    End Sub

    Private Sub ComboBox142_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox142.SelectedIndexChanged
        shot2Calculator(TextBox14, TextBox13, TextBox12, ComboBox141, ComboBox142, ComboBox151, 1, 4)
        ComboBox141.Enabled = False
    End Sub

    Private Sub ComboBox151_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox151.SelectedIndexChanged
        shot1Calculator(TextBox15, TextBox14, TextBox13, ComboBox151, ComboBox152, ComboBox161, 1, 5)
        ComboBox151.Enabled = False
    End Sub

    Private Sub ComboBox152_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox152.SelectedIndexChanged
        shot2Calculator(TextBox15, TextBox14, TextBox13, ComboBox151, ComboBox152, ComboBox161, 1, 5)
        ComboBox152.Enabled = False
    End Sub

    Private Sub ComboBox161_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox161.SelectedIndexChanged
        shot1Calculator(TextBox16, TextBox15, TextBox14, ComboBox161, ComboBox162, ComboBox171, 1, 6)
        ComboBox161.Enabled = False
    End Sub

    Private Sub ComboBox162_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox162.SelectedIndexChanged
        shot2Calculator(TextBox16, TextBox15, TextBox14, ComboBox161, ComboBox162, ComboBox171, 1, 6)
        ComboBox162.Enabled = False
    End Sub

    Private Sub ComboBox171_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox171.SelectedIndexChanged
        shot1Calculator(TextBox17, TextBox16, TextBox15, ComboBox171, ComboBox172, ComboBox181, 1, 7)
        ComboBox171.Enabled = False
    End Sub

    Private Sub ComboBox172_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox172.SelectedIndexChanged
        shot2Calculator(TextBox17, TextBox16, TextBox15, ComboBox171, ComboBox172, ComboBox181, 1, 7)
        ComboBox172.Enabled = False
    End Sub

    Private Sub ComboBox181_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox181.SelectedIndexChanged
        shot1Calculator(TextBox18, TextBox17, TextBox16, ComboBox181, ComboBox182, ComboBox191, 1, 8)
        ComboBox181.Enabled = False
    End Sub

    Private Sub ComboBox182_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox182.SelectedIndexChanged
        shot2Calculator(TextBox18, TextBox17, TextBox16, ComboBox181, ComboBox182, ComboBox191, 1, 8)
        ComboBox182.Enabled = False
    End Sub

    Private Sub ComboBox191_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox191.SelectedIndexChanged
        shot1Calculator(TextBox19, TextBox18, TextBox17, ComboBox191, ComboBox192, ComboBox1101, 1, 9)
        ComboBox191.Enabled = False
    End Sub

    Private Sub ComboBox192_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox192.SelectedIndexChanged
        shot2Calculator(TextBox19, TextBox18, TextBox17, ComboBox191, ComboBox192, ComboBox1101, 1, 9)
        ComboBox192.Enabled = False
    End Sub

    Private Sub ComboBox1101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1101.SelectedIndexChanged
        Dim value As String
        value = ComboBox1101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox1102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox1102.Items.Add(i)
                Next
                ComboBox1102.Items.Add("X")
                ComboBox1102.Enabled = True
                ComboBox1103.Items.Clear()
                TextBox110.Text = ""
            Else
                ComboBox1102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox1102.Items.Add(i)
                Next
                ComboBox1102.Items.Add("/")
                ComboBox1102.Enabled = True
                ComboBox1103.Items.Clear()
                TextBox110.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox1102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox1101.SelectedItem
        value2 = ComboBox1102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox1103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox1103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox1103.Items.Add(i)
                    Next
                    ComboBox1103.Items.Add("/")
                Else
                    ComboBox1103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox1103.Items.Add(i)
                    Next
                    ComboBox1103.Items.Add("X")
                End If
                TextBox110.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox1103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox1103.Items.Add(i)
                    Next
                    ComboBox1103.Items.Add("X")
                    ComboBox1103.Enabled = True
                    TextBox110.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox1103.Enabled = False
                    ComboBox1103.Items.Clear()
                    Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, 0, 1)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox1101.SelectedItem
        value2 = ComboBox1102.SelectedItem
        value3 = ComboBox1103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox110, TextBox19, TextBox18, 10, v1, v2, v3, 1)
        End If
    End Sub

    Private Sub ComboBox211_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox211.SelectedIndexChanged
        shot1Calculator(TextBox21, TextBox21, TextBox21, ComboBox211, ComboBox212, ComboBox221, 2, 1)
        ComboBox211.Enabled = False
    End Sub

    Private Sub ComboBox212_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox212.SelectedIndexChanged
        shot2Calculator(TextBox21, TextBox21, TextBox21, ComboBox211, ComboBox212, ComboBox221, 2, 1)
        ComboBox212.Enabled = False
    End Sub

    Private Sub ComboBox221_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox221.SelectedIndexChanged
        shot1Calculator(TextBox22, TextBox21, TextBox21, ComboBox221, ComboBox222, ComboBox231, 2, 2)
        ComboBox221.Enabled = False
    End Sub

    Private Sub ComboBox222_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox222.SelectedIndexChanged
        shot2Calculator(TextBox22, TextBox21, TextBox21, ComboBox221, ComboBox222, ComboBox231, 2, 2)
        ComboBox222.Enabled = False
    End Sub

    Private Sub ComboBox231_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox231.SelectedIndexChanged
        shot1Calculator(TextBox23, TextBox22, TextBox21, ComboBox231, ComboBox232, ComboBox241, 2, 3)
        ComboBox231.Enabled = False
    End Sub

    Private Sub ComboBox232_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox232.SelectedIndexChanged
        shot2Calculator(TextBox23, TextBox22, TextBox21, ComboBox231, ComboBox232, ComboBox241, 2, 3)
        ComboBox232.Enabled = False
    End Sub

    Private Sub ComboBox241_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox241.SelectedIndexChanged
        shot1Calculator(TextBox24, TextBox23, TextBox22, ComboBox241, ComboBox242, ComboBox251, 2, 4)
        ComboBox241.Enabled = False
    End Sub

    Private Sub ComboBox242_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox242.SelectedIndexChanged
        shot2Calculator(TextBox24, TextBox23, TextBox22, ComboBox241, ComboBox242, ComboBox251, 2, 4)
        ComboBox242.Enabled = False
    End Sub

    Private Sub ComboBox251_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox251.SelectedIndexChanged
        shot1Calculator(TextBox25, TextBox24, TextBox23, ComboBox251, ComboBox252, ComboBox261, 2, 5)
        ComboBox251.Enabled = False
    End Sub

    Private Sub ComboBox252_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox252.SelectedIndexChanged
        shot2Calculator(TextBox25, TextBox24, TextBox23, ComboBox251, ComboBox252, ComboBox261, 2, 5)
        ComboBox252.Enabled = False
    End Sub

    Private Sub ComboBox261_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox261.SelectedIndexChanged
        shot1Calculator(TextBox26, TextBox25, TextBox24, ComboBox261, ComboBox262, ComboBox271, 2, 6)
        ComboBox261.Enabled = False
    End Sub

    Private Sub ComboBox262_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox262.SelectedIndexChanged
        shot2Calculator(TextBox26, TextBox25, TextBox24, ComboBox261, ComboBox262, ComboBox271, 2, 6)
        ComboBox262.Enabled = False
    End Sub

    Private Sub ComboBox271_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox271.SelectedIndexChanged
        shot1Calculator(TextBox27, TextBox26, TextBox25, ComboBox271, ComboBox272, ComboBox281, 2, 7)
        ComboBox271.Enabled = False
    End Sub

    Private Sub ComboBox272_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox272.SelectedIndexChanged
        shot2Calculator(TextBox27, TextBox26, TextBox25, ComboBox271, ComboBox272, ComboBox281, 2, 7)
        ComboBox272.Enabled = False
    End Sub

    Private Sub ComboBox281_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox281.SelectedIndexChanged
        shot1Calculator(TextBox28, TextBox27, TextBox26, ComboBox281, ComboBox282, ComboBox291, 2, 8)
        ComboBox281.Enabled = False
    End Sub

    Private Sub ComboBox282_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox282.SelectedIndexChanged
        shot2Calculator(TextBox28, TextBox27, TextBox26, ComboBox281, ComboBox282, ComboBox291, 2, 8)
        ComboBox282.Enabled = False
    End Sub

    Private Sub ComboBox291_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox291.SelectedIndexChanged
        shot1Calculator(TextBox29, TextBox28, TextBox27, ComboBox291, ComboBox292, ComboBox2101, 2, 9)
        ComboBox291.Enabled = False
    End Sub

    Private Sub ComboBox292_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox292.SelectedIndexChanged
        shot2Calculator(TextBox29, TextBox28, TextBox27, ComboBox291, ComboBox292, ComboBox2101, 2, 9)
        ComboBox292.Enabled = False
    End Sub

    Private Sub ComboBox2101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2101.SelectedIndexChanged
        Dim value As String
        value = ComboBox2101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox2102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox2102.Items.Add(i)
                Next
                ComboBox2102.Items.Add("X")
                ComboBox2102.Enabled = True
                ComboBox2103.Items.Clear()
                TextBox210.Text = ""
            Else
                ComboBox2102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox2102.Items.Add(i)
                Next
                ComboBox2102.Items.Add("/")
                ComboBox2102.Enabled = True
                ComboBox2103.Items.Clear()
                TextBox210.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox2102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox2101.SelectedItem
        value2 = ComboBox2102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox2103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox2103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox2103.Items.Add(i)
                    Next
                    ComboBox2103.Items.Add("/")
                Else
                    ComboBox2103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox2103.Items.Add(i)
                    Next
                    ComboBox2103.Items.Add("X")
                End If
                TextBox210.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox2103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox2103.Items.Add(i)
                    Next
                    ComboBox2103.Items.Add("X")
                    ComboBox2103.Enabled = True
                    TextBox210.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox2103.Enabled = False
                    ComboBox2103.Items.Clear()
                    Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, 0, 2)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox2103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox2101.SelectedItem
        value2 = ComboBox2102.SelectedItem
        value3 = ComboBox2103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox210, TextBox29, TextBox28, 10, v1, v2, v3, 2)
        End If
    End Sub

    Private Sub ComboBox311_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox311.SelectedIndexChanged
        shot1Calculator(TextBox31, TextBox31, TextBox31, ComboBox311, ComboBox312, ComboBox321, 3, 1)
        ComboBox311.Enabled = False
    End Sub

    Private Sub ComboBox312_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox312.SelectedIndexChanged
        shot2Calculator(TextBox31, TextBox31, TextBox31, ComboBox311, ComboBox312, ComboBox321, 3, 1)
        ComboBox312.Enabled = False
    End Sub

    Private Sub ComboBox321_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox321.SelectedIndexChanged
        shot1Calculator(TextBox32, TextBox31, TextBox31, ComboBox321, ComboBox322, ComboBox331, 3, 2)
        ComboBox321.Enabled = False
    End Sub

    Private Sub ComboBox322_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox322.SelectedIndexChanged
        shot2Calculator(TextBox32, TextBox31, TextBox31, ComboBox321, ComboBox322, ComboBox331, 3, 2)
        ComboBox322.Enabled = False
    End Sub

    Private Sub ComboBox331_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox331.SelectedIndexChanged
        shot1Calculator(TextBox33, TextBox32, TextBox31, ComboBox331, ComboBox332, ComboBox341, 3, 3)
        ComboBox331.Enabled = False
    End Sub

    Private Sub ComboBox332_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox332.SelectedIndexChanged
        shot2Calculator(TextBox33, TextBox32, TextBox31, ComboBox331, ComboBox332, ComboBox341, 3, 3)
        ComboBox332.Enabled = False
    End Sub

    Private Sub ComboBox341_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox341.SelectedIndexChanged
        shot1Calculator(TextBox34, TextBox33, TextBox32, ComboBox341, ComboBox342, ComboBox351, 3, 4)
        ComboBox341.Enabled = False
    End Sub

    Private Sub ComboBox342_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox342.SelectedIndexChanged
        shot2Calculator(TextBox34, TextBox33, TextBox32, ComboBox341, ComboBox342, ComboBox351, 3, 4)
        ComboBox342.Enabled = False
    End Sub

    Private Sub ComboBox351_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox351.SelectedIndexChanged
        shot1Calculator(TextBox35, TextBox34, TextBox33, ComboBox351, ComboBox352, ComboBox361, 3, 5)
        ComboBox351.Enabled = False
    End Sub

    Private Sub ComboBox352_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox352.SelectedIndexChanged
        shot2Calculator(TextBox35, TextBox34, TextBox33, ComboBox351, ComboBox352, ComboBox361, 3, 5)
        ComboBox352.Enabled = False
    End Sub

    Private Sub ComboBox361_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox361.SelectedIndexChanged
        shot1Calculator(TextBox36, TextBox35, TextBox34, ComboBox361, ComboBox362, ComboBox371, 3, 6)
        ComboBox361.Enabled = False
    End Sub

    Private Sub ComboBox362_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox362.SelectedIndexChanged
        shot2Calculator(TextBox36, TextBox35, TextBox34, ComboBox361, ComboBox362, ComboBox371, 3, 6)
        ComboBox362.Enabled = False
    End Sub

    Private Sub ComboBox371_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox371.SelectedIndexChanged
        shot1Calculator(TextBox37, TextBox36, TextBox35, ComboBox371, ComboBox372, ComboBox381, 3, 7)
        ComboBox371.Enabled = False
    End Sub

    Private Sub ComboBox372_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox372.SelectedIndexChanged
        shot2Calculator(TextBox37, TextBox36, TextBox35, ComboBox371, ComboBox372, ComboBox381, 3, 7)
        ComboBox372.Enabled = False
    End Sub

    Private Sub ComboBox381_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox381.SelectedIndexChanged
        shot1Calculator(TextBox38, TextBox37, TextBox36, ComboBox381, ComboBox382, ComboBox391, 3, 8)
        ComboBox381.Enabled = False
    End Sub

    Private Sub ComboBox382_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox382.SelectedIndexChanged
        shot2Calculator(TextBox38, TextBox37, TextBox36, ComboBox381, ComboBox382, ComboBox391, 3, 8)
        ComboBox382.Enabled = False
    End Sub

    Private Sub ComboBox391_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox391.SelectedIndexChanged
        shot1Calculator(TextBox39, TextBox38, TextBox37, ComboBox391, ComboBox392, ComboBox3101, 3, 9)
        ComboBox391.Enabled = False
    End Sub

    Private Sub ComboBox392_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox392.SelectedIndexChanged
        shot2Calculator(TextBox39, TextBox38, TextBox37, ComboBox391, ComboBox392, ComboBox3101, 3, 9)
        ComboBox392.Enabled = False
    End Sub

    Private Sub ComboBox3101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3101.SelectedIndexChanged
        Dim value As String
        value = ComboBox3101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox3102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox3102.Items.Add(i)
                Next
                ComboBox3102.Items.Add("X")
                ComboBox3102.Enabled = True
                ComboBox3103.Items.Clear()
                TextBox310.Text = ""
            Else
                ComboBox3102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox3102.Items.Add(i)
                Next
                ComboBox3102.Items.Add("/")
                ComboBox3102.Enabled = True
                ComboBox3103.Items.Clear()
                TextBox310.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox3102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox3101.SelectedItem
        value2 = ComboBox3102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox3103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox3103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox3103.Items.Add(i)
                    Next
                    ComboBox3103.Items.Add("/")
                Else
                    ComboBox3103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox3103.Items.Add(i)
                    Next
                    ComboBox3103.Items.Add("X")
                End If
                TextBox310.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox3103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox3103.Items.Add(i)
                    Next
                    ComboBox3103.Items.Add("X")
                    ComboBox3103.Enabled = True
                    TextBox310.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox3103.Enabled = False
                    ComboBox3103.Items.Clear()
                    Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, 0, 3)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox3103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox3101.SelectedItem
        value2 = ComboBox3102.SelectedItem
        value3 = ComboBox3103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox310, TextBox39, TextBox38, 10, v1, v2, v3, 3)
        End If
    End Sub

    Private Sub ComboBox411_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox411.SelectedIndexChanged
        shot1Calculator(TextBox41, TextBox41, TextBox41, ComboBox411, ComboBox412, ComboBox421, 4, 1)
        ComboBox411.Enabled = False
    End Sub

    Private Sub ComboBox412_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox412.SelectedIndexChanged
        shot2Calculator(TextBox41, TextBox41, TextBox41, ComboBox411, ComboBox412, ComboBox421, 4, 1)
        ComboBox412.Enabled = False
    End Sub

    Private Sub ComboBox421_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox421.SelectedIndexChanged
        shot1Calculator(TextBox42, TextBox41, TextBox41, ComboBox421, ComboBox422, ComboBox431, 4, 2)
        ComboBox421.Enabled = False
    End Sub

    Private Sub ComboBox422_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox422.SelectedIndexChanged
        shot2Calculator(TextBox42, TextBox41, TextBox41, ComboBox421, ComboBox422, ComboBox431, 4, 2)
        ComboBox422.Enabled = False
    End Sub

    Private Sub ComboBox431_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox431.SelectedIndexChanged
        shot1Calculator(TextBox43, TextBox42, TextBox41, ComboBox431, ComboBox432, ComboBox441, 4, 3)
        ComboBox431.Enabled = False
    End Sub

    Private Sub ComboBox432_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox432.SelectedIndexChanged
        shot2Calculator(TextBox43, TextBox42, TextBox41, ComboBox431, ComboBox432, ComboBox441, 4, 3)
        ComboBox432.Enabled = False
    End Sub

    Private Sub ComboBox441_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox441.SelectedIndexChanged
        shot1Calculator(TextBox44, TextBox43, TextBox42, ComboBox441, ComboBox442, ComboBox451, 4, 4)
        ComboBox441.Enabled = False
    End Sub

    Private Sub ComboBox442_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox442.SelectedIndexChanged
        shot2Calculator(TextBox44, TextBox43, TextBox42, ComboBox441, ComboBox442, ComboBox451, 4, 4)
        ComboBox442.Enabled = False
    End Sub

    Private Sub ComboBox451_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox451.SelectedIndexChanged
        shot1Calculator(TextBox45, TextBox44, TextBox43, ComboBox451, ComboBox452, ComboBox461, 4, 5)
        ComboBox451.Enabled = False
    End Sub

    Private Sub ComboBox452_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox452.SelectedIndexChanged
        shot2Calculator(TextBox45, TextBox44, TextBox43, ComboBox451, ComboBox452, ComboBox461, 4, 5)
        ComboBox452.Enabled = False
    End Sub

    Private Sub ComboBox461_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox461.SelectedIndexChanged
        shot1Calculator(TextBox46, TextBox45, TextBox44, ComboBox461, ComboBox462, ComboBox471, 4, 6)
        ComboBox461.Enabled = False
    End Sub

    Private Sub ComboBox462_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox462.SelectedIndexChanged
        shot2Calculator(TextBox46, TextBox45, TextBox44, ComboBox461, ComboBox462, ComboBox471, 4, 6)
        ComboBox462.Enabled = False
    End Sub

    Private Sub ComboBox471_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox471.SelectedIndexChanged
        shot1Calculator(TextBox47, TextBox46, TextBox45, ComboBox471, ComboBox472, ComboBox481, 4, 7)
        ComboBox471.Enabled = False
    End Sub

    Private Sub ComboBox472_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox472.SelectedIndexChanged
        shot2Calculator(TextBox47, TextBox46, TextBox45, ComboBox471, ComboBox472, ComboBox481, 4, 7)
        ComboBox472.Enabled = False
    End Sub

    Private Sub ComboBox481_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox481.SelectedIndexChanged
        shot1Calculator(TextBox48, TextBox47, TextBox46, ComboBox481, ComboBox482, ComboBox491, 4, 8)
        ComboBox481.Enabled = False
    End Sub

    Private Sub ComboBox482_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox482.SelectedIndexChanged
        shot2Calculator(TextBox48, TextBox47, TextBox46, ComboBox481, ComboBox482, ComboBox491, 4, 8)
        ComboBox482.Enabled = False
    End Sub

    Private Sub ComboBox491_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox491.SelectedIndexChanged
        shot1Calculator(TextBox49, TextBox48, TextBox47, ComboBox491, ComboBox492, ComboBox4101, 4, 9)
        ComboBox491.Enabled = False
    End Sub

    Private Sub ComboBox492_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox492.SelectedIndexChanged
        shot2Calculator(TextBox49, TextBox48, TextBox47, ComboBox491, ComboBox492, ComboBox4101, 4, 9)
        ComboBox492.Enabled = False
    End Sub

    Private Sub ComboBox4101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4101.SelectedIndexChanged
        Dim value As String
        value = ComboBox4101.SelectedItem
        If Not String.IsNullOrEmpty(value) Then
            If value.Equals("X") Then
                ComboBox4102.Items.Clear()
                For i As Integer = 0 To 9 Step 1
                    ComboBox4102.Items.Add(i)
                Next
                ComboBox4102.Items.Add("X")
                ComboBox4102.Enabled = True
                ComboBox4103.Items.Clear()
                TextBox410.Text = ""
            Else
                ComboBox4102.Items.Clear()
                For i As Integer = 0 To (9 - value) Step 1
                    ComboBox4102.Items.Add(i)
                Next
                ComboBox4102.Items.Add("/")
                ComboBox4102.Enabled = True
                ComboBox4103.Items.Clear()
                TextBox410.Text = ""
            End If
        End If
    End Sub

    Private Sub ComboBox4102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4102.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim v1 As Integer
        Dim v2 As Integer
        value1 = ComboBox4101.SelectedItem
        value2 = ComboBox4102.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) Then
            If value1.Equals("X") Then
                ComboBox4103.Enabled = True
                If Not value2.Equals("X") Then
                    ComboBox4103.Items.Clear()
                    For i As Integer = 0 To (9 - CInt(value2)) Step 1
                        ComboBox4103.Items.Add(i)
                    Next
                    ComboBox4103.Items.Add("/")
                Else
                    ComboBox4103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox4103.Items.Add(i)
                    Next
                    ComboBox4103.Items.Add("X")
                End If
                TextBox410.Text = ""
            Else
                If value2.Equals("/") Then
                    ComboBox4103.Items.Clear()
                    For i As Integer = 0 To 9 Step 1
                        ComboBox4103.Items.Add(i)
                    Next
                    ComboBox4103.Items.Add("X")
                    ComboBox4103.Enabled = True
                    TextBox410.Text = ""
                Else
                    v1 = CInt(value1)
                    v2 = CInt(value2)
                    ComboBox1101.Enabled = False
                    ComboBox4103.Items.Clear()
                    Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, 0, 4)
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox4103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4103.SelectedIndexChanged
        Dim value1 As String
        Dim value2 As String
        Dim value3 As String
        Dim v1 As Integer
        Dim v2 As Integer
        Dim v3 As Integer
        value1 = ComboBox4101.SelectedItem
        value2 = ComboBox4102.SelectedItem
        value3 = ComboBox4103.SelectedItem
        If Not String.IsNullOrEmpty(value1) And Not String.IsNullOrEmpty(value2) And Not String.IsNullOrEmpty(value3) Then
            If value1.Equals("X") Then
                v1 = 10
            Else
                v1 = CInt(value1)
            End If

            If value2.Equals("X") Then
                v2 = 10
            ElseIf value2.Equals("/") Then
                v2 = 10 - v1
            Else
                v2 = CInt(value2)
            End If

            If value3.Equals("X") Then
                v3 = 10
            ElseIf value3.Equals("/") Then
                v3 = 10 - v2
            Else
                v3 = CInt(value3)
            End If

            Calculate(TextBox410, TextBox49, TextBox48, 10, v1, v2, v3, 4)
        End If
    End Sub

    <DllImport("user32.dll")> Public Shared Function SendMessageW(hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_MUTE))
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_DOWN))
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_UP))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        First = Val(TextBox110.Text)
        Second = Val(TextBox210.Text)
        Third = Val(TextBox310.Text)
        Fourth = Val(TextBox410.Text)



        If Panel1.Visible = True And Panel2.Visible = False And Panel3.Visible = False And Panel4.Visible = False And ComboBox1102.Enabled = False Then
            MsgBox("Please enter all player scores before finalising your game!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = False And Panel4.Visible = False And ComboBox1102.Enabled = False And ComboBox2102.Enabled = False Then
            MsgBox("Please enter all player scores before finalising your game!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = False And ComboBox1102.Enabled = False And ComboBox2102.Enabled = False And ComboBox3102.Enabled = False Then
            MsgBox("Please enter all player scores before finalising your game!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = True And ComboBox1102.Enabled = False And ComboBox2102.Enabled = False And ComboBox3102.Enabled = False And ComboBox4102.Enabled = False Then
            MsgBox("Please enter all player scores before finalising your game!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = True And (First > Second) And (First > Third) And (First > Fourth) Then
            Max = First
            MsgBox("Congratulations " & Name1.Text & " you outplayed the competition and are the winner of this round!!!, please start your next game by pressing reset.")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = True And (Second > First) And (Second > Third) And (Second > Fourth) Then
            Max = Second
            MsgBox("Congratulations " & Name2.Text & " you outplayed the competition and are the winner of this round!!!, please start your next game by pressing reset.")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = True And (Third > First) And (Third > Second) And (Third > Fourth) Then
            Max = Third
            MsgBox("Congratulations " & Name3.Text & " you outplayed the competition and are the winner of this round!!!, please start your next game by pressing reset.")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = True Then
            Max = Fourth
            MsgBox("Congratulations " & Name4.Text & " you outplayed the competition and are the winner of this round!!!, please start your next game by pressing reset.")

        End If


        If Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = False And ComboBox111.Enabled = False And ComboBox3102.Enabled = True And (First > Second) And (First > Third) Then
            Max = First
            MsgBox("Congratulations " & Name1.Text & " you outplayed the competition and are the winner of this round, to start your next game, hit reset!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = False And (Second > First) And (Second > Third) Then
            Max = Second
            MsgBox("Congratulations " & Name2.Text & " you outplayed the competition and are the winner of this round, to start your next game, hit reset!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = True And Panel4.Visible = False And (Third > First) And (Third > Second) Then
            Max = Third
            MsgBox("Congratulations " & Name3.Text & " you outplayed the competition and are the winner of this round, to start your next game, hit reset!")

        End If

        If Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = False And Panel4.Visible = False And ComboBox111.Enabled = False And ComboBox2102.Enabled = True And (First > Second) Then
            Max = First
            MsgBox("Congratulations " & Name1.Text & " you outplayed the competition and are the winner of this round, to start your next game, hit reset!")
        ElseIf Panel1.Visible = True And Panel2.Visible = True And Panel3.Visible = False And Panel4.Visible = False And (Second > First) Then
            Max = Second
            MsgBox("Congratulations " & Name2.Text & " you outplayed the competition and are the winner of this round, to start your next game, hit reset!")

        End If


        If Panel1.Visible = True And Panel2.Visible = False And Panel3.Visible = False And Panel4.Visible = False And ComboBox111.Enabled = False And ComboBox1102.Enabled = True Then
            Max = First
            MsgBox("Congratulations " & Name1.Text & "You achieved a score of " & TextBox110.Text & " , to begin a new round, click new game")


        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel3.Visible = False
        Panel4.Visible = False
        Panel2.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel2.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel4.Visible = False
        Panel2.Visible = True
        Panel3.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button1.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button7.Enabled = True

        Name1.Text = ""
        Name2.Text = ""
        Name3.Text = ""
        Name4.Text = ""

        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox110.Text = ""

        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox29.Text = ""
        TextBox210.Text = ""

        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox37.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox310.Text = ""

        TextBox41.Text = ""
        TextBox42.Text = ""
        TextBox43.Text = ""
        TextBox44.Text = ""
        TextBox45.Text = ""
        TextBox46.Text = ""
        TextBox47.Text = ""
        TextBox48.Text = ""
        TextBox49.Text = ""
        TextBox410.Text = ""

        ComboBox111.SelectedIndex = -1
        ComboBox112.SelectedIndex = -1
        ComboBox121.SelectedIndex = -1
        ComboBox122.SelectedIndex = -1
        ComboBox131.SelectedIndex = -1
        ComboBox132.SelectedIndex = -1
        ComboBox141.SelectedIndex = -1
        ComboBox142.SelectedIndex = -1
        ComboBox151.SelectedIndex = -1
        ComboBox152.SelectedIndex = -1
        ComboBox161.SelectedIndex = -1
        ComboBox162.SelectedIndex = -1
        ComboBox171.SelectedIndex = -1
        ComboBox172.SelectedIndex = -1
        ComboBox181.SelectedIndex = -1
        ComboBox182.SelectedIndex = -1
        ComboBox191.SelectedIndex = -1
        ComboBox192.SelectedIndex = -1
        ComboBox1101.SelectedIndex = -1
        ComboBox1102.SelectedIndex = -1
        ComboBox1103.SelectedIndex = -1

        ComboBox211.SelectedIndex = -1
        ComboBox212.SelectedIndex = -1
        ComboBox221.SelectedIndex = -1
        ComboBox222.SelectedIndex = -1
        ComboBox231.SelectedIndex = -1
        ComboBox232.SelectedIndex = -1
        ComboBox241.SelectedIndex = -1
        ComboBox242.SelectedIndex = -1
        ComboBox251.SelectedIndex = -1
        ComboBox252.SelectedIndex = -1
        ComboBox261.SelectedIndex = -1
        ComboBox262.SelectedIndex = -1
        ComboBox271.SelectedIndex = -1
        ComboBox272.SelectedIndex = -1
        ComboBox281.SelectedIndex = -1
        ComboBox282.SelectedIndex = -1
        ComboBox291.SelectedIndex = -1
        ComboBox292.SelectedIndex = -1
        ComboBox2101.SelectedIndex = -1
        ComboBox2102.SelectedIndex = -1
        ComboBox2103.SelectedIndex = -1

        ComboBox311.SelectedIndex = -1
        ComboBox312.SelectedIndex = -1
        ComboBox321.SelectedIndex = -1
        ComboBox322.SelectedIndex = -1
        ComboBox331.SelectedIndex = -1
        ComboBox332.SelectedIndex = -1
        ComboBox341.SelectedIndex = -1
        ComboBox342.SelectedIndex = -1
        ComboBox351.SelectedIndex = -1
        ComboBox352.SelectedIndex = -1
        ComboBox361.SelectedIndex = -1
        ComboBox362.SelectedIndex = -1
        ComboBox371.SelectedIndex = -1
        ComboBox372.SelectedIndex = -1
        ComboBox381.SelectedIndex = -1
        ComboBox382.SelectedIndex = -1
        ComboBox391.SelectedIndex = -1
        ComboBox392.SelectedIndex = -1
        ComboBox3101.SelectedIndex = -1
        ComboBox3102.SelectedIndex = -1
        ComboBox3103.SelectedIndex = -1

        ComboBox411.SelectedIndex = -1
        ComboBox412.SelectedIndex = -1
        ComboBox421.SelectedIndex = -1
        ComboBox422.SelectedIndex = -1
        ComboBox431.SelectedIndex = -1
        ComboBox432.SelectedIndex = -1
        ComboBox441.SelectedIndex = -1
        ComboBox442.SelectedIndex = -1
        ComboBox451.SelectedIndex = -1
        ComboBox452.SelectedIndex = -1
        ComboBox461.SelectedIndex = -1
        ComboBox462.SelectedIndex = -1
        ComboBox471.SelectedIndex = -1
        ComboBox472.SelectedIndex = -1
        ComboBox481.SelectedIndex = -1
        ComboBox482.SelectedIndex = -1
        ComboBox491.SelectedIndex = -1
        ComboBox492.SelectedIndex = -1
        ComboBox4101.SelectedIndex = -1
        ComboBox4102.SelectedIndex = -1
        ComboBox4103.SelectedIndex = -1

        ComboBox112.Enabled = False
        ComboBox121.Enabled = False
        ComboBox122.Enabled = False
        ComboBox131.Enabled = False
        ComboBox132.Enabled = False
        ComboBox141.Enabled = False
        ComboBox142.Enabled = False
        ComboBox151.Enabled = False
        ComboBox152.Enabled = False
        ComboBox161.Enabled = False
        ComboBox162.Enabled = False
        ComboBox171.Enabled = False
        ComboBox172.Enabled = False
        ComboBox181.Enabled = False
        ComboBox182.Enabled = False
        ComboBox191.Enabled = False
        ComboBox192.Enabled = False
        ComboBox1101.Enabled = False
        ComboBox1102.Enabled = False
        ComboBox1103.Enabled = False

        ComboBox212.Enabled = False
        ComboBox221.Enabled = False
        ComboBox222.Enabled = False
        ComboBox231.Enabled = False
        ComboBox232.Enabled = False
        ComboBox241.Enabled = False
        ComboBox242.Enabled = False
        ComboBox251.Enabled = False
        ComboBox252.Enabled = False
        ComboBox261.Enabled = False
        ComboBox262.Enabled = False
        ComboBox271.Enabled = False
        ComboBox272.Enabled = False
        ComboBox281.Enabled = False
        ComboBox282.Enabled = False
        ComboBox291.Enabled = False
        ComboBox292.Enabled = False
        ComboBox2101.Enabled = False
        ComboBox2102.Enabled = False
        ComboBox2103.Enabled = False

        ComboBox312.Enabled = False
        ComboBox321.Enabled = False
        ComboBox322.Enabled = False
        ComboBox331.Enabled = False
        ComboBox332.Enabled = False
        ComboBox341.Enabled = False
        ComboBox342.Enabled = False
        ComboBox351.Enabled = False
        ComboBox352.Enabled = False
        ComboBox361.Enabled = False
        ComboBox362.Enabled = False
        ComboBox371.Enabled = False
        ComboBox372.Enabled = False
        ComboBox381.Enabled = False
        ComboBox382.Enabled = False
        ComboBox391.Enabled = False
        ComboBox392.Enabled = False
        ComboBox3101.Enabled = False
        ComboBox3102.Enabled = False
        ComboBox3103.Enabled = False

        ComboBox412.Enabled = False
        ComboBox421.Enabled = False
        ComboBox422.Enabled = False
        ComboBox431.Enabled = False
        ComboBox432.Enabled = False
        ComboBox441.Enabled = False
        ComboBox442.Enabled = False
        ComboBox451.Enabled = False
        ComboBox452.Enabled = False
        ComboBox461.Enabled = False
        ComboBox462.Enabled = False
        ComboBox471.Enabled = False
        ComboBox472.Enabled = False
        ComboBox481.Enabled = False
        ComboBox482.Enabled = False
        ComboBox491.Enabled = False
        ComboBox492.Enabled = False
        ComboBox4101.Enabled = False
        ComboBox4102.Enabled = False
        ComboBox4103.Enabled = False

        ComboBox111.Enabled = False
        ComboBox211.Enabled = False
        ComboBox311.Enabled = False
        ComboBox411.Enabled = False

        For i As Integer = 0 To 10 Step 1
            framevalues1(i) = 0
            framevalues2(i) = 0
            framevalues3(i) = 0
            framevalues4(i) = 0
        Next

        strikes1.Clear()
        strikes2.Clear()
        strikes3.Clear()
        strikes4.Clear()
        spares1.Clear()
        spares2.Clear()
        spares3.Clear()
        spares4.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Name1.Text = "" Then
            MsgBox("Please enter all player names before beggining your game!")
        Else
            ComboBox111.Enabled = True
            ComboBox211.Enabled = True
            ComboBox311.Enabled = True
            ComboBox411.Enabled = True

            Button1.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button7.Enabled = False

        End If


        ComboBox111.Enabled = True
        ComboBox211.Enabled = True
        ComboBox311.Enabled = True
        ComboBox411.Enabled = True

        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button7.Enabled = False
    End Sub

    Private Sub scorecard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox111.Enabled = False
        ComboBox211.Enabled = False
        ComboBox311.Enabled = False
        ComboBox411.Enabled = False
    End Sub
End Class
