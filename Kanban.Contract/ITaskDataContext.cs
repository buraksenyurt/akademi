namespace Kanban.Contract;

/*
    Önceki tasarımda okuma ve kaydetme işlevleri farklı arayüzlerde tutulmuştur. 
    Bu, yazma ve okuma işlemlerinin farklı enstrümanlar ile yapılabileceği anlamına da gelir. 
    Ancak design böyle olmak zorunda değildir. Aşağıdaki gibi de tasarlayabiliriz.
*/

public interface ITaskDataContext
{
    IEnumerable<Entity.Task> GetAll();
    string Save(IEnumerable<Entity.Task> tasks);
}