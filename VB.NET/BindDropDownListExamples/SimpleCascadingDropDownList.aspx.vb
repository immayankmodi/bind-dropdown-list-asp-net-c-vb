Imports System.Data.SqlClient

Public Class SimpleCascadingDropDownList
    Inherits System.Web.UI.Page

    'specify your connection string here..
    Public Shared strConn As String = "Data Source=datasource;Integrated Security=true;Initial Catalog=database"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCountryList()
        End If
    End Sub

    'bind countries to country dropdownlist
    Private Sub BindCountryList()
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT CountryId,CountryName FROM Country"
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim da As New SqlDataAdapter(sqlCmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    ddlCountry.DataSource = dt
                    ddlCountry.DataValueField = "CountryId"
                    ddlCountry.DataTextField = "CountryName"
                    ddlCountry.DataBind()
                    sqlConn.Close()

                    'Adding "Please select country" option in dropdownlist
                    ddlCountry.Items.Insert(0, New ListItem("Please select country", "0"))

                    'Adding initially value to "state" and "city" dropdownlist
                    ddlState.Items.Insert(0, New ListItem("Please select state", "0"))
                    ddlCity.Items.Insert(0, New ListItem("Please select city", "0"))
                End Using
            End Using
        Catch
        End Try
    End Sub

    'bind states to state dropdownlist on country change event
    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT StateId,StateName FROM State WHERE CountryId=@CountryId"
                    sqlCmd.Parameters.AddWithValue("@CountryId", ddlCountry.SelectedValue)
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim da As New SqlDataAdapter(sqlCmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    ddlState.DataSource = dt
                    ddlState.DataValueField = "StateId"
                    ddlState.DataTextField = "StateName"
                    ddlState.DataBind()
                    sqlConn.Close()

                    'Adding "Please select state" option in dropdownlist
                    ddlState.Items.Insert(0, New ListItem("Please select state", "0"))

                    'also clear city dropdownlist because we are changing country
                    ddlCity.Items.Clear()
                    ddlCity.Items.Insert(0, New ListItem("Please select city", "0"))
                End Using
            End Using
        Catch
        End Try
    End Sub

    'bind cities to city dropdownlist on state change event
    Protected Sub ddlState_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Using sqlConn As New SqlConnection(strConn)
                Using sqlCmd As New SqlCommand()
                    sqlCmd.CommandText = "SELECT CityId,CityName FROM City WHERE StateId=@StateId"
                    sqlCmd.Parameters.AddWithValue("@StateId", ddlState.SelectedValue)
                    sqlCmd.Connection = sqlConn
                    sqlConn.Open()
                    Dim da As New SqlDataAdapter(sqlCmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    ddlCity.DataSource = dt
                    ddlCity.DataValueField = "CityId"
                    ddlCity.DataTextField = "CityName"
                    ddlCity.DataBind()
                    sqlConn.Close()

                    'Adding "Please select city" option in dropdownlist
                    ddlCity.Items.Insert(0, New ListItem("Please select city", "0"))
                End Using
            End Using
        Catch
        End Try
    End Sub

End Class