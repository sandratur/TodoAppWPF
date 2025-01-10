using TodoAppWPF;

namespace TestingTodoList
{
    public class ToDoListTests
    {
        private TodoList _todoList;
        public ToDoListTests()
        {
            _todoList = new TodoList();
        }

        [Fact]
        public void AddTask_ShouldAddTaskToList()
        {
            var task = "Test task";
            _todoList.AddTask(task);
            var tasks = _todoList.GetAllTasks();
            Assert.Contains(task, tasks);
        }

        [Fact]
        public void RemoveTask_ShouldRemoveTaskFromList()
        {
            var task = "Task to remove";
            _todoList.AddTask(task);
            _todoList.RemoveTask(0);
            var tasks = _todoList.GetAllTasks();
            Assert.DoesNotContain(task, tasks);
        }

        [Fact]
        public void RemoveTask_InvalidIndex_ShouldNotThrowException()
        {
            var task = "Valid Task";
            _todoList.AddTask(task);
            _todoList.RemoveTask(10); //ogiltit index
            var tasks = _todoList.GetAllTasks();
            Assert.Single(tasks); //Den ursprungliga upg. ska finnas kvar
        }
    }
}