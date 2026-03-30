using System;

namespace Lab5
{
    public class Task2
    {
        public static void Execute()
        {
            CreateAndDestroyObjects();
            
            Console.WriteLine("Forcing Garbage Collection to trigger destructors...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Done.");
        }

        private static void CreateAndDestroyObjects()
        {
            TrialV2[] trials = new TrialV2[]
            {
                new TestV2(),
                new ExamV2("Physics"),
                new FinalExamV2("Computer Science", 120, "Prof. Johnson", 85)
            };

            foreach (var trial in trials)
            {
                trial.Show();
            }
        }
    }

    public abstract class TrialV2
    {
        protected string subject;
        protected int durationMinutes;

        public TrialV2() : this("Unknown", 0) { }
        public TrialV2(string subject) : this(subject, 60) { }
        public TrialV2(string subject, int durationMinutes)
        {
            this.subject = subject;
            this.durationMinutes = durationMinutes;
            Console.WriteLine($"TrialV2 Constructor called: {subject}");
        }

        ~TrialV2()
        {
            Console.WriteLine($"TrialV2 Destructor called: {subject}");
        }

        public abstract void Show();
    }

    public class TestV2 : TrialV2
    {
        protected int questionsCount;

        public TestV2() : this("General Test", 30, 10) { }
        public TestV2(string subject) : this(subject, 45, 20) { }
        public TestV2(string subject, int durationMinutes, int questionsCount) 
            : base(subject, durationMinutes)
        {
            this.questionsCount = questionsCount;
            Console.WriteLine($"TestV2 Constructor called: {subject}");
        }

        ~TestV2()
        {
            Console.WriteLine($"TestV2 Destructor called: {subject}");
        }

        public override void Show() => Console.WriteLine($"[TestV2] {subject}");
    }

    public class ExamV2 : TrialV2
    {
        protected string examiner;

        public ExamV2() : this("General Exam", 60, "Unknown Examiner") { }
        public ExamV2(string subject) : this(subject, 90, "Pending") { }
        public ExamV2(string subject, int durationMinutes, string examiner) 
            : base(subject, durationMinutes)
        {
            this.examiner = examiner;
            Console.WriteLine($"ExamV2 Constructor called: {subject}");
        }

        ~ExamV2()
        {
            Console.WriteLine($"ExamV2 Destructor called: {subject}");
        }

        public override void Show() => Console.WriteLine($"[ExamV2] {subject}");
    }

    public class FinalExamV2 : ExamV2
    {
        protected int minPassingScore;

        public FinalExamV2() : this("General Final", 120, "Board", 50) { }
        public FinalExamV2(string subject) : this(subject, 120, "Board", 60) { }
        public FinalExamV2(string subject, int durationMinutes, string examiner, int minPassingScore) 
            : base(subject, durationMinutes, examiner)
        {
            this.minPassingScore = minPassingScore;
            Console.WriteLine($"FinalExamV2 Constructor called: {subject}");
        }

        ~FinalExamV2()
        {
            Console.WriteLine($"FinalExamV2 Destructor called: {subject}");
        }

        public override void Show() => Console.WriteLine($"[FinalExamV2] {subject}");
    }
}