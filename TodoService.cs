namespace Ticketing
{
    public class TodoService
    {
        private List<Todo> listTodo = new();

        public List<Todo> GetAllTodo() => listTodo;
        public Todo? GetById(int id) => listTodo.Find(t => t.id == id);

        public bool Delete(int id)
        {
            var todo = GetById(id);
            if (todo != null)
            {
                listTodo.Remove(todo);
                return true;
            }
            return false;
        }

        public Todo AddTodo(string title)
        {
            var idTemp = listTodo.Count > 0 ? listTodo.Max(t => t.id) + 1 : 1;
            var todo = new Todo(idTemp, title, DateTime.Now);
            listTodo.Add(todo);
            return todo;
        }

        public void Update(int id, Todo itemTodo)
        {
            Delete(id);
            listTodo.Add(new Todo(id, itemTodo.titre, itemTodo.startDate, itemTodo.endDate));
        }
    }
}