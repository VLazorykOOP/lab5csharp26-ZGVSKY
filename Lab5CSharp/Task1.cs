using System;
using System.Linq;

namespace Lab5
{
    public class Task1
    {
        public static void Execute()
        {
            Trial[] trials = new Trial[]
            {
                new Test("Mathematics", 60, 50),
                new Exam("Physics", 90, "Dr. Smith"),
                new FinalExam("Computer Science", 120, "Prof. Johnson", 85),
                new Test("History", 45, 20),
                new Exam("Literature", 100, "Dr. Brown")
            };

            var sortedTrials = trials.OrderBy(t => t.DurationMinutes).ToArray();

            Console.WriteLine("--- Trials sorted by duration ---");
            foreach (var trial in sortedTrials)
            {
                trial.Show();
            }
        }
    }

    public abstract class Trial
    {
        protected string subject;
        protected int durationMinutes;

        public Trial(string subject, int durationMinutes)
        {
            this.subject = subject;
            this.durationMinutes = durationMinutes;
        }

        public int DurationMinutes => durationMinutes;

        public abstract void Show();
    }

    public class Test : Trial
    {
        protected int questionsCount;

        public Test(string subject, int durationMinutes, int questionsCount) 
            : base(subject, durationMinutes)
        {
            this.questionsCount = questionsCount;
        }

        public override void Show()
        {
            Console.WriteLine($"[Test] Subject: {subject}, Duration: {durationMinutes}m, Questions: {questionsCount}");
        }
    }

    public class Exam : Trial
    {
        protected string examiner;

        public Exam(string subject, int durationMinutes, string examiner) 
            : base(subject, durationMinutes)
        {
            this.examiner = examiner;
        }

        public override void Show()
        {
            Console.WriteLine($"[Exam] Subject: {subject}, Duration: {durationMinutes}m, Examiner: {examiner}");
        }
    }

    public class FinalExam : Exam
    {
        protected int minPassingScore;

        public FinalExam(string subject, int durationMinutes, string examiner, int minPassingScore) 
            : base(subject, durationMinutes, examiner)
        {
            this.minPassingScore = minPassingScore;
        }

        public override void Show()
        {
            Console.WriteLine($"[FinalExam] Subject: {subject}, Duration: {durationMinutes}m, Examiner: {examiner}, Min Score: {minPassingScore}");
        }
    }
}