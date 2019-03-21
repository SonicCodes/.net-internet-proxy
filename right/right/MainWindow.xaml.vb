Imports System.Timers
Imports System.Threading
Imports System.IO
Imports Fiddler
Imports System.Net
Imports System.Windows.Media.Animation

Class MainWindow

    Private Sub Window_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs) Handles MyBase.DragEnter

    End Sub

    Private Sub sds_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles sds.MouseMove


    End Sub

    Private Sub sds_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles sds.MouseDown
        sds.BorderThickness = New Thickness(3)
        Me.Cursor = Cursors.Hand
        Me.DragMove()


    End Sub
    Public Function HaveInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function
    Private Sub sds_DragLeave(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs) Handles sds.DragLeave

    End Sub

    Private Sub sds_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles sds.MouseUp


    End Sub

    Private Sub sds_MouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles sds.MouseLeave
        If (Me.Top < 0) Then
            Me.Top = 5
        End If
        If (Me.Left < 0) Then
            Me.Left = 5
        End If

      
        sds.BorderThickness = New Thickness(0)
        Me.Cursor = Cursors.Arrow
    End Sub
    Dim oldd = 0
    Dim oldu = 0
    Public Function detm(ByVal TheSize As Double) As String
        Dim DoubleBytes As Double




        DoubleBytes = CDbl(TheSize / 1024) 'MB
        Return FormatNumber(DoubleBytes, 1) & " KB"


    End Function
    Private Sub start()

        ' The following code is a rendition of one provided by
        ' Firestarter_75, so he gets the credit here:

        Dim applicationName As String = "Count"
        Dim applicationPath As String = Directory.GetCurrentDirectory() + "\right.exe"


        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        regKey.SetValue(applicationName, """" & applicationPath & """")
        regKey.Close()


        ' Assuming that you'll run this as a setup form of some sort
        ' and call it using .ShowDialog, simply close this form to
        ' return to the main program
        Close()
    End Sub

    Private Sub StartProxy()

        If Not FiddlerApplication.IsSystemProxy Then
            AddHandler FiddlerApplication.BeforeResponse, AddressOf FiddlerBeforeResponseHandler
            AddHandler FiddlerApplication.BeforeRequest, AddressOf FiddlerBeforeRequestHandler
        End If

        FiddlerApplication.Startup(8090, True, False, True)

    End Sub
    Sub animwidth(ByVal cont As Grid, ByVal width As Integer)
   
    End Sub
    Private Sub FiddlerBeforeRequestHandler(ByVal tSession As Session)
        Me.Dispatcher.Invoke(
System.Windows.Threading.DispatcherPriority.Normal, Sub()

                                                        shup(Image2, True)
                                                        Dim str As New Thread(Sub()
                                                                                  Thread.Sleep(100)
                                                                                  Me.Dispatcher.Invoke(
System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                        shup(Image2, False)
                                                    End Sub)

                                                                              End Sub)
                                                        str.Start()
                                                    End Sub)


    End Sub

    Private Sub FiddlerBeforeResponseHandler(ByVal tSession As Session)
        Try
            Me.Dispatcher.Invoke(
System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                        shup(Image4, True)


                                                        Dim str As New Thread(Sub()
                                                                                  Thread.Sleep(100)
                                                                                  Me.Dispatcher.Invoke(
System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                        shup(Image4, False)
                                                    End Sub)

                                                                              End Sub)
                                                        str.Start()
                                                        If (tSession.uriContains(".ico") = False) Then


                                                            name.Content = tSession.url
                                                            desc.Content = tSession.state

                                                        Else
                                                            Try
                                                                If (tSession.responseCode = 200) Then
                                                                    Dim image As New BitmapImage()


                                                                    Using mem = New MemoryStream(tSession.ResponseBody)

                                                                        image.BeginInit()

                                                                        image.StreamSource = mem
                                                                        image.EndInit()

                                                                    End Using
                                                                    Image1.Source = image
                                                                End If

                                                            Catch ex As Exception
                                                                MessageBox.Show(ex.Message)
                                                            End Try

                                                        End If

                                                    End Sub)


        Catch ex As Exception

        End Try

    End Sub



    Private Sub StopProxy()

        Try
            RemoveHandler FiddlerApplication.BeforeResponse, AddressOf FiddlerBeforeResponseHandler
            RemoveHandler FiddlerApplication.BeforeRequest, AddressOf FiddlerBeforeRequestHandler
            FiddlerApplication.Shutdown()
            System.Threading.Thread.Sleep(500)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim time As New System.Timers.Timer
        time.Interval = 1000
        time.AutoReset = True
        StartProxy()
        time.Enabled = True
        Dim asr = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces(0)

        Dim netStatistics As System.Net.NetworkInformation.IPv4InterfaceStatistics = asr.GetIPv4Statistics
        oldd = netStatistics.BytesReceived
        oldu = netStatistics.BytesSent

        AddHandler time.Elapsed, Sub()

                                     Dim thr As New Thread(Sub()
                                                               If (HaveInternetConnection()) Then
                                                                   Me.Dispatcher.Invoke(
System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                        err.Visibility = Windows.Visibility.Hidden

                                                    End Sub)

                                                                   Dim netStatisticss As System.Net.NetworkInformation.IPv4InterfaceStatistics = asr.GetIPv4Statistics
                                                                   Dim dw = detm((oldd - netStatisticss.BytesReceived))
                                                                   Dim up = detm((oldu - netStatisticss.BytesSent))
                                                                   Dim rdw = (oldd - netStatisticss.BytesReceived)
                                                                   Dim rup = (oldu - netStatisticss.BytesSent)

                                                             


                                                                   Me.Dispatcher.Invoke(
    System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                            Label1.Content = "U:" + up.Replace("-", "") + "/S"
                                                            Label2.Content = "D:" + dw.Replace("-", "") + "/S"

                                                        End Sub)


                                                                   netStatistics = asr.GetIPv4Statistics
                                                                   oldd = netStatistics.BytesReceived
                                                                   oldu = netStatistics.BytesSent

                                                               Else
                                                                   Me.Dispatcher.Invoke(
System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                        err.Visibility = Windows.Visibility.Visible

                                                    End Sub)
                                                               End If
                                                           End Sub)
                                     thr.Start()





                                 End Sub

        time.Start()

    End Sub
    Sub shup(ByVal image As Image, ByVal bloo As Boolean)
        If (bloo = True) Then
            image.Dispatcher.Invoke(
               System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                                       image.Visibility = Windows.Visibility.Visible
                                                                       animwidth(sdf, 148)
                                                                   End Sub
                   )
        Else
            image.Dispatcher.Invoke(
                           System.Windows.Threading.DispatcherPriority.Normal, Sub()
                                                                                   image.Visibility = Windows.Visibility.Collapsed
                                                                               End Sub
                               )

        End If


    End Sub

    Private Sub Window_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = True
    End Sub

    Private Sub Window_DragLeave(ByVal sender As System.Object, ByVal e As System.Windows.DragEventArgs) Handles MyBase.DragLeave
  
    End Sub

    Private Sub Label3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Label3.MouseUp
     

    End Sub

    Private Sub Label3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Label3.MouseDown
        Dim s As New info
        s.Show()
    End Sub
    Sub animsize(ByVal value As Size)
        Dim height = value.Height
        Dim width = value.Width
        Dim WidenLeft As New DoubleAnimation
        WidenLeft.To = height
        WidenLeft.Duration = TimeSpan.FromSeconds(0.5)
        sdf.BeginAnimation(HeightProperty, WidenLeft)

        Dim WidenRight As New DoubleAnimation
        WidenRight.To = width
        WidenRight.Duration = TimeSpan.FromSeconds(0.5)
        sdf.BeginAnimation(WidthProperty, WidenRight)


    End Sub
    Private Sub Label4_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Label4.MouseDoubleClick
        If (Label4.Content = "-") Then
            animsize(New Size(60, 60))
            Label4.Content = "+"

        Else
            animsize(New Size(148, 131))
            Label4.Content = "-"
        End If

    End Sub

    Private Sub Label5_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Label5.MouseDoubleClick
        Dim s As New Proxy
        s.Show()
    End Sub
End Class
