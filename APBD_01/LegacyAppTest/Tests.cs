using LegacyApp;

namespace LegacyAppTest;

public class Tests
{
    
    private class PerfectUser
    {
        public String name = "John";
        public String lastName = "Doe";
        public String mail = "johndoe@gmail.com";
        public DateTime birthDate = DateTime.Parse("1982-03-21");
        public int id = 1;
    }
    [Fact]
    public void UserService_AddUser_Should_Return_False_When_Name_Or_Last_Name_Are_Empty()
    {
        // Arrange
        var usr = new PerfectUser();
        // Act
        var us = new UserService();
        // Assert
        Assert.False(us.AddUser(usr.name, "", usr.mail, usr.birthDate, usr.id));
    }
    [Fact]
    public void UserService_AddUser_Should_Return_False_When_Email_Dont_Contains_At_And_Dot()
    {
        // Arrange
        var usr = new PerfectUser();
        // Act
        var us = new UserService();
        // Assert
        Assert.False(us.AddUser(usr.name, usr.lastName, "johndgmailcom", usr.birthDate, usr.id));
        
    }
    [Fact]
    public void UserService_AddUser_Should_Return_False_When_Age_is_Below_21()
    {
        // Arrange
        var usr = new PerfectUser();
        // Act
        var us = new UserService();
        // Assert
        Assert.False(us.AddUser(usr.name, usr.lastName, usr.mail, DateTime.Parse("2020-03-21"), usr.id));
    }
    [Fact]
    public void UserService_AddUser_Should_Return_True_If_User_Has_CreditLimit_And_Its_Above_500_Or_User_Dont_Have_Credit_Limit()
    {
        // Arrange
        var usr = new PerfectUser();
        
        // Act
        var us = new UserService();
        
        // Assert
        Assert.True(us.AddUser(usr.name, usr.lastName, usr.mail, usr.birthDate, 1));
    }
}