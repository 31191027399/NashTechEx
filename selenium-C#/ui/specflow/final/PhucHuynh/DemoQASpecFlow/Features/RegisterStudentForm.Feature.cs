﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DemoQASpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Register Student Form")]
    [NUnit.Framework.CategoryAttribute("registerStudentForm")]
    public partial class RegisterStudentFormFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "registerStudentForm"};
        
#line 1 "RegisterStudentForm.Feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Register Student Form", "    User want to Register a new student", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Register student form successfully")]
        [NUnit.Framework.TestCaseAttribute("Register student form with all fields successfully", "Phuc", "Huynh", "zsad@gmail.com", "Male", "0123456789", "08 December,2001", "Maths, Chemistry", "Sports, Reading", "image.jpg", "45 Bahama", "NCR", "Noida", null)]
        [NUnit.Framework.TestCaseAttribute("Register student form with required fields only", "Phuc", "Huynh", "", "Male", "0123456789", "", "", "", "", "", "", "", null)]
        public void RegisterStudentFormSuccessfully(string scenario, string firstName, string lastName, string email, string gender, string mobile, string dateOfBirth, string subjects, string hobbies, string picture, string currentAddress, string state, string city, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Scenario", scenario);
            argumentsOfScenario.Add("firstName", firstName);
            argumentsOfScenario.Add("lastName", lastName);
            argumentsOfScenario.Add("email", email);
            argumentsOfScenario.Add("gender", gender);
            argumentsOfScenario.Add("mobile", mobile);
            argumentsOfScenario.Add("dateOfBirth", dateOfBirth);
            argumentsOfScenario.Add("subjects", subjects);
            argumentsOfScenario.Add("hobbies", hobbies);
            argumentsOfScenario.Add("picture", picture);
            argumentsOfScenario.Add("currentAddress", currentAddress);
            argumentsOfScenario.Add("state", state);
            argumentsOfScenario.Add("city", city);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Register student form successfully", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
        testRunner.Given("User is on Student Registration Form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table1.AddRow(new string[] {
                            "firstName",
                            string.Format("{0}", firstName)});
                table1.AddRow(new string[] {
                            "lastName",
                            string.Format("{0}", lastName)});
                table1.AddRow(new string[] {
                            "email",
                            string.Format("{0}", email)});
                table1.AddRow(new string[] {
                            "gender",
                            string.Format("{0}", gender)});
                table1.AddRow(new string[] {
                            "mobile",
                            string.Format("{0}", mobile)});
                table1.AddRow(new string[] {
                            "dateOfBirth",
                            string.Format("{0}", dateOfBirth)});
                table1.AddRow(new string[] {
                            "subjects",
                            string.Format("{0}", subjects)});
                table1.AddRow(new string[] {
                            "hobbies",
                            string.Format("{0}", hobbies)});
                table1.AddRow(new string[] {
                            "picture",
                            string.Format("{0}", picture)});
                table1.AddRow(new string[] {
                            "currentAddress",
                            string.Format("{0}", currentAddress)});
                table1.AddRow(new string[] {
                            "state",
                            string.Format("{0}", state)});
                table1.AddRow(new string[] {
                            "city",
                            string.Format("{0}", city)});
#line 8
        testRunner.When("the user input valid data into all fields", ((string)(null)), table1, "When ");
#line hidden
#line 22
        testRunner.And("the user clicks on Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
        testRunner.Then("a successful message is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2.AddRow(new string[] {
                            "firstName",
                            string.Format("{0}", firstName)});
                table2.AddRow(new string[] {
                            "lastName",
                            string.Format("{0}", lastName)});
                table2.AddRow(new string[] {
                            "email",
                            string.Format("{0}", email)});
                table2.AddRow(new string[] {
                            "gender",
                            string.Format("{0}", gender)});
                table2.AddRow(new string[] {
                            "mobile",
                            string.Format("{0}", mobile)});
                table2.AddRow(new string[] {
                            "dateOfBirth",
                            string.Format("{0}", dateOfBirth)});
                table2.AddRow(new string[] {
                            "subjects",
                            string.Format("{0}", subjects)});
                table2.AddRow(new string[] {
                            "hobbies",
                            string.Format("{0}", hobbies)});
                table2.AddRow(new string[] {
                            "picture",
                            string.Format("{0}", picture)});
                table2.AddRow(new string[] {
                            "currentAddress",
                            string.Format("{0}", currentAddress)});
                table2.AddRow(new string[] {
                            "state",
                            string.Format("{0}", state)});
                table2.AddRow(new string[] {
                            "city",
                            string.Format("{0}", city)});
#line 24
        testRunner.And("all information of the student form is shown correctly", ((string)(null)), table2, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion