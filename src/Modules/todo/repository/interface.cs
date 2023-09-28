using System.ComponentModel;

namespace backend_challenge.Modules.todo.repository;

public interface ITodo {
    Task<Todo> create(Todo entity);
    Task<Todo?> readOne(Guid id);
    Task<List<Todo>> readList();
    Task<Todo> update(Todo entity);
    Task<int> delete(Guid id);
    Task<Todo> completeTask(Todo entity);
}

public enum TodoStatus
{
    [Description("Pending")]
    Pending,
    [Description("Progress")]
    Progress,
    [Description("Completed")]
    Completed
}