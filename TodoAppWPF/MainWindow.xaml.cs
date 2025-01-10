using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TodoList _todolist;
        public MainWindow()
        {
            InitializeComponent();
            _todolist = new TodoList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">sender fr mainwindow</param>
        /// <param name="e">event</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string task = TaskTextBox.Text;
            if (!string.IsNullOrEmpty(task))
            {
                _todolist.AddTask(task);
                UpdateTaskList();
                TaskTextBox.Clear();
            }

        }

        private void UpdateTaskList()
        {
            TasksListBox.Items.Clear();
            foreach (var task in _todolist.GetAllTasks())
            {
                TasksListBox.Items.Add(task);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedIndex >= 0)
            {
                _todolist.RemoveTask(TasksListBox.SelectedIndex);
                UpdateTaskList();
            }
        }
    }
}