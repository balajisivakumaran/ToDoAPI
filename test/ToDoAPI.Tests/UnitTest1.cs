using ToDoAPI.Models;

namespace ToDoAPI.Tests;

public class ToDoModelTests
{
    [Fact]
    public void CanChangeName()
    {
        //Arrange
        var toDoModelData = new ToDoItem{
            Name = "Adding my first unit test",
        };

        //Act
        toDoModelData.Name = "Actually, I want to call it as maiden unit test";

        //Assert
        Assert.Equal("Adding my first unit test", toDoModelData.Name);
    }
}