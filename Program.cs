//Coleccion
List<string> TaskList = new List<string>();
int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Remove);

//Show the options for Task, 
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string menuSelect = Console.ReadLine();
    return Convert.ToInt32(menuSelect);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTaskList();

        string taskNumberToDelete = Console.ReadLine();

        // remove on positibon beacuse the array start in 0
        int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
            System.Console.WriteLine("Numero de tarea seleccionado no es valido");
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }
    }
    catch (Exception)
    {
        System.Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskAdd = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(taskAdd))
        {
            System.Console.WriteLine("No se permiten campos nullos");
        }
        else
        {
            TaskList.Add(taskAdd);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        System.Console.WriteLine("Ha surgido un erro al ingresar la tarea");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

//Funcion
void ShowTaskList()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    TaskList.ForEach(p => Console.WriteLine($"{++indexTask} . {p}"));
    Console.WriteLine("----------------------------------------");
}
public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

