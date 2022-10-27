namespace StudentPicker;

internal class Program
{
    private static int GetNumOfStudents()
    {
        // Get number of students
        int numOfStudents = 0;
        Console.WriteLine("Enter a number of students:");
        string studentsInput = Console.ReadLine();
        while (!int.TryParse(studentsInput, out numOfStudents) || studentsInput == "")
        {
            Console.WriteLine("Enter a number of students:");
            studentsInput = Console.ReadLine();
        }
        return numOfStudents;
    }

    private static int GetNumOfExercises()
    {
        // Get number of exercises
        int numOfExercises = 0;
        Console.WriteLine("Enter a number of exercises:");
        string exercisesInput = Console.ReadLine();
        while (!int.TryParse(exercisesInput, out numOfExercises) || exercisesInput == "")
        {
            Console.WriteLine("Enter a number of exercises:");
            exercisesInput = Console.ReadLine();
        }
        return numOfExercises;
    }

    private static int GetNumOfQuestions()
    {
        // Get number of questions
        int numOfQuestions = 0;
        Console.WriteLine("Enter a number of questions asked:");
        string questionsInput = Console.ReadLine();
        while (!int.TryParse(questionsInput, out numOfQuestions) || questionsInput == "")
        {
            Console.WriteLine("Enter a number of questions asked:");
            questionsInput = Console.ReadLine();
        }
        return numOfQuestions;
    }

    static void Main(string[] args)
    {
        try
        {
            Random random = new Random();
            List<int> usedExercises = new List<int>();
            List<int> usedStudents = new List<int>();
            int numOfStudents = 0;
            int numOfExercises = 0;
            int numOfQuestions = 0;

            if (args.Length < 2)
            {
                numOfStudents = GetNumOfStudents();
                numOfExercises = GetNumOfExercises();
                numOfQuestions = GetNumOfQuestions();
            }
            else
            {
                if (!int.TryParse(args[0], out numOfStudents)) numOfStudents = GetNumOfStudents();
                if (!int.TryParse(args[1], out numOfExercises)) numOfExercises = GetNumOfExercises();
                if (!int.TryParse(args[2], out numOfQuestions)) numOfQuestions = GetNumOfQuestions();
            }

            Console.WriteLine($"\nInserted number of students: {numOfStudents}.");
            Console.WriteLine($"Inserted number of exercises: {numOfExercises}.");
            Console.WriteLine($"Inserted number of questions asked: {numOfQuestions}.");
            Console.WriteLine("###################################");

            int pickNumber = 1;
            while (numOfStudents > usedStudents.Count && (numOfExercises - usedExercises.Count) >= numOfQuestions)
            {
                var studentRange = Enumerable.Range(1, numOfStudents).Where(i => !usedStudents.Contains(i));
                int studentIndex = random.Next(0, numOfStudents - usedStudents.Count);
                int pickedStudent = studentRange.ElementAt(studentIndex);
                Console.WriteLine($"\n{pickNumber}. Student: {pickedStudent}");
                usedStudents.Add(pickedStudent);
                pickNumber++;

                for (int i = 0; i < numOfQuestions; i++)
                {
                    var exerciseRange = Enumerable.Range(1, numOfExercises).Where(i => !usedExercises.Contains(i));
                    int exerciseIndex = random.Next(0, numOfExercises - usedExercises.Count);
                    int pickedExercise = exerciseRange.ElementAt(exerciseIndex);
                    usedExercises.Add(pickedExercise);
                    Console.WriteLine($"    - Exercise: {pickedExercise}");
                }

                Console.ReadKey();
            }

            if (numOfStudents == usedStudents.Count) Console.WriteLine("No more students left!");
            if ((numOfExercises - usedExercises.Count) < numOfQuestions) Console.WriteLine("Not enough exercises left!");
        }
        catch (Exception ex)
        {
            // Exception handler
            Console.WriteLine("!!!There has been an error with the application, to see the details press 'y'!!!");
            string input = Console.ReadLine();

            if (input != null && input.Equals("y")) Console.WriteLine(ex.Message);
        }
        finally
        {
            // Application exit prompt
            Console.WriteLine("\nPress any key to close the application");
            Console.ReadKey();
        }
    }
}