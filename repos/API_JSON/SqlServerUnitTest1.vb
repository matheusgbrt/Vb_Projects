Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Microsoft.Data.Tools.Schema.Sql.UnitTesting
Imports Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class SqlServerUnitTest1
    Inherits SqlDatabaseTestClass

    Sub New()
        InitializeComponent()
    End Sub

    <TestInitialize()>
    Public Sub TestInitialize()
        InitializeTest()
    End Sub

    <TestCleanup()>
    Public Sub TestCleanup()
        CleanupTest()
    End Sub

    <TestMethod()>
    Public Sub SqlTest1()
        Dim testActions As SqlDatabaseTestActions = Me.SqlTest1Data
        'Execute the pre-test script
        '
        System.Diagnostics.Trace.WriteLineIf(testActions.PretestAction IsNot Nothing, "Executing pre-test script...")
        Dim pretestResults() As SqlExecutionResult = TestService.Execute(Me.PrivilegedContext, Me.PrivilegedContext, testActions.PretestAction)
        'Execute the test script
        '
        System.Diagnostics.Trace.WriteLineIf(testActions.TestAction IsNot Nothing, "Executing test script...")
        Dim testResults() As SqlExecutionResult = TestService.Execute(Me.ExecutionContext, Me.PrivilegedContext, testActions.TestAction)
        'Execute the post-test script
        '
        System.Diagnostics.Trace.WriteLineIf(testActions.PosttestAction IsNot Nothing, "Executing post-test script...")
        Dim posttestResults() As SqlExecutionResult = TestService.Execute(Me.PrivilegedContext, Me.PrivilegedContext, testActions.PosttestAction)
    End Sub

#Region "Designer support code"

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim SqlTest1_TestAction As Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SqlServerUnitTest1))
        Dim InconclusiveCondition1 As Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition
        Dim RowCountCondition1 As Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition
        Me.SqlTest1Data = New Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions()
        SqlTest1_TestAction = New Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction()
        InconclusiveCondition1 = New Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition()
        RowCountCondition1 = New Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition()
        '
        'SqlTest1Data
        '
        Me.SqlTest1Data.PosttestAction = Nothing
        Me.SqlTest1Data.PretestAction = Nothing
        Me.SqlTest1Data.TestAction = SqlTest1_TestAction
        '
        'SqlTest1_TestAction
        '
        SqlTest1_TestAction.Conditions.Add(InconclusiveCondition1)
        SqlTest1_TestAction.Conditions.Add(RowCountCondition1)
        resources.ApplyResources(SqlTest1_TestAction, "SqlTest1_TestAction")
        '
        'InconclusiveCondition1
        '
        InconclusiveCondition1.Enabled = True
        InconclusiveCondition1.Name = "InconclusiveCondition1"
        '
        'RowCountCondition1
        '
        RowCountCondition1.Enabled = True
        RowCountCondition1.Name = "RowCountCondition1"
        RowCountCondition1.ResultSet = 1
        RowCountCondition1.RowCount = 0
    End Sub

#End Region

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
#End Region

    Private SqlTest1Data As SqlDatabaseTestActions
End Class

