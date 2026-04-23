using System;
using System.Collections.Generic;

class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Course { get; set; }
    public uint StudentId { get; set; } 
    public string Gender { get; set; }
    public double AverageGrade { get; set; }

    public Student(string lastName, string firstName, int course, uint studentId, string gender, double averageGrade)
    {
        LastName = lastName;
        FirstName = firstName;
        Course = course;
        StudentId = studentId;
        Gender = gender;
        AverageGrade = averageGrade;
    }

    public override string ToString()
    {
        return String.Format("| {0,-10} | {1,-10} | {2,-4} | {3,-11} | {4,-6} | {5,-5:F1} |", 
            LastName, FirstName, Course, StudentId, Gender, AverageGrade);
    }
}

class TreeNode
{
    public Student Data { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(Student data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    private TreeNode root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(Student student)
    {
        root = InsertRecursive(root, student);
    }

    private TreeNode InsertRecursive(TreeNode node, Student student)
    {
        if (node == null)
            return new TreeNode(student);

        if (student.StudentId < node.Data.StudentId)
            node.Left = InsertRecursive(node.Left, student);
        else if (student.StudentId > node.Data.StudentId)
            node.Right = InsertRecursive(node.Right, student);

        return node;
    }

    public void PrintBreadthFirst()
    {
        if (root == null)
        {
            Console.WriteLine("The tree is empty.");
            return;
        }

        Console.WriteLine(new String('-', 67));
        Console.WriteLine("| Last Name  | First Name | Year | Student ID  | Gender | Grade |");
        Console.WriteLine(new String('-', 67));

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            Console.WriteLine(current.Data.ToString());

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }
        Console.WriteLine(new String('-', 67));
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        tree.Insert(new Student("Kovalenko", "Oleg", 2, 5000, "Male", 4.5)); 
        tree.Insert(new Student("Petrenko", "Anna", 1, 3000, "Female", 4.8));  
        tree.Insert(new Student("Boiko", "Ihor", 2, 7000, "Male", 4.2));     
        tree.Insert(new Student("Melnyk", "Ivan", 2, 2000, "Male", 3.5));   
        tree.Insert(new Student("Tkachenko", "Vlad", 2, 4000, "Male", 5.0));  
        tree.Insert(new Student("Shevchuk", "Olena", 3, 8000, "Female", 4.0));   

        Console.WriteLine("\n=== BREADTH-FIRST TRAVERSAL (LEVEL 1) ===");
        tree.PrintBreadthFirst();
        Console.WriteLine();
    }
}