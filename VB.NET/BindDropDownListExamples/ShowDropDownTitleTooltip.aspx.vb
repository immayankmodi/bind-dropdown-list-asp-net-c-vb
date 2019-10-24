Imports System.Data.SqlClient

Public Class ShowDropDownTitleTooltip
    Inherits System.Web.UI.Page

    'specify your connection string here..
    Public Shared strConn As String = "Data Source=datasource;Integrated Security=true;Initial Catalog=database"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDropDownList()
        End If
    End Sub

    'bind subject names to dropdownlist
    Private Sub BindDropDownList()
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT SubjectId,SubjectName FROM SubjectDetails"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim da As New SqlDataAdapter(sqlCmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    ddlSubjects.DataSource = dt
                    ddlSubjects.DataValueField = "SubjectId"
                    ddlSubjects.DataTextField = "SubjectName"
                    ddlSubjects.DataBind()
                    sqlConn.Close()

                    'Adding "Please select" option in dropdownlist for validation
                    ddlSubjects.Items.Insert(0, New ListItem("Please select", "0"))
                End Using
            End Using
        Catch
        End Try
    End Sub

    'OnDataBound event to bound title tooltip
    Protected Sub ddlSubjects_OnDataBound(ByVal sender As Object, ByVal e As EventArgs)
        Dim dd As DropDownList = TryCast(sender, DropDownList)
        If dd IsNot Nothing Then
            For Each li As ListItem In dd.Items
                li.Attributes("title") = li.Text
            Next li
        End If
    End Sub

End Class