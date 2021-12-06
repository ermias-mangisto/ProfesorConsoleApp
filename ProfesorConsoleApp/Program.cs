using GradesConsoleApp;
List<Professor> list = new List<Professor>();
List<string> students = new List<string>();
GradeApp(list, students);


static void GradeApp(List<Professor> list, List<string> students)
{
    Console.WriteLine("hello prof  \n 1.add grades \n 2.avrage \n 3.second\n 4. by index \n 5.all");
    switch (Console.ReadLine())
    {
        case "1":
            try
            {
                int i = int.Parse(Console.ReadLine());
                string inputName = Console.ReadLine();
                
                ProfFileSheet(i, inputName, list,students);
                
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                GradeApp(list, students);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                GradeApp(list, students);
            }

            GradeApp(list, students);
            break;
        case "2":
            Console.WriteLine("which prof");
            try {
                Avg(Console.ReadLine()); 
            }
            catch(FormatException ex){

            Console.WriteLine(ex.Message);
                GradeApp(list, students);
            }
            
            break;
        case "3":
            Console.WriteLine("which");
            try
            {
              second(Console.ReadLine());
            }
            catch(FormatException ex)
            { Console.WriteLine(ex.Message);}
            
            break;
            case"4":
            FindByIndex(Console.ReadLine(),int.Parse(Console.ReadLine()));
            
            break;
        case "5":
            
            foreach (string student in students)
            {
                Console.WriteLine(student);
            }
            break;
    }


}

static void ProfFileSheet(int i, string inputName, List<Professor> list,List<string> students)
{
    int num = 0;
    while (i > 0)
    {
        string student = Console.ReadLine();
        string id = Console.ReadLine();
        List<int> grades = new List<int>();
        grades.Add(int.Parse(Console.ReadLine()));
        grades.Add(int.Parse(Console.ReadLine()));
        grades.Add(int.Parse(Console.ReadLine()));
        Console.WriteLine("...........");
        Professor newProf = new Professor(inputName, student, id, grades);
        list.Add(newProf);
        AddToFile(newProf, num);
       
        num++;
        i--;
    } AddToList(inputName, students);
}
static void AddToFile(Professor prof, int num)
{

    FileStream professorFile = new FileStream($@"C:\grades\{prof.professorName}.txt", FileMode.Append);
    using (StreamWriter writer = new StreamWriter(professorFile))
    {
        writer.WriteLine($" id:{num}  name: {prof.studentName} taz: {prof.studentId} grades: [{prof.grades[0]},{prof.grades[1]},{prof.grades[2]}]");

    }

}

static void AddToList(string name, List<string> list)
{
    FileStream professorFile = new FileStream($@"C:\grades\{name}.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(professorFile))
    {
        int i = 0;
        while (i < reader.Peek())
        {
 list.Add(reader.ReadLine());
            i++;
        }
       

    }

}
static void Avg(string prof)
{
    FileStream professorFile = new FileStream($@"C:\grades\{prof}.txt", FileMode.Open);
    using (StreamReader read = new StreamReader(professorFile))
    {
        string str = read.ReadLine();
        int name = str.IndexOf("name:") + 5;
        int endName = str.IndexOf("taz") - name;
        string str2 = str.Substring(name, endName);
        int find = str.IndexOf("[");
        string nums = str.Substring(find + 1, str.Length - find - 2);
        string[] subs = nums.Split(',');
        int sum = 0;
        foreach (string sub in subs)
        {
            sum += int.Parse(sub);
        }
        Console.WriteLine($"{str2}avg:{sum / 3}");
    }


}
static void second(string prof)
{
    FileStream professorFile = new FileStream($@"C:\grades\{prof}.txt", FileMode.Open);
    using (StreamReader read = new StreamReader(professorFile))
    {
        read.ReadLine();
        Console.WriteLine(read.ReadLine());
    }
}
static void FindByIndex(string prof, int index)
{
    FileStream professorFile = new FileStream($@"C:\grades\{prof}.txt", FileMode.Open);
    using (StreamReader read = new StreamReader(professorFile))
    { int i = 0;
       List<string> lines= new List<string>();
        while(i < read.Peek())
            {
            lines.Add(read.ReadLine());
            i++;
        }
        foreach (string line in lines)
        {
            int start = line.IndexOf(":") + 1;
            int end = line.IndexOf("name");
            int num = int.Parse(line.Substring(start, end - start));
            if (index == num)
            { 
                Console.WriteLine(line);
            }
        }
    }
}