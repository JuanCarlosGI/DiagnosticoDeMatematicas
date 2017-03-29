using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.ExamsService
{
    public class ExamsService : IExamsService
    {
        private readonly SiteContext _db;
        public ExamsService() { }

        public ExamsService(SiteContext db)
        {
            _db = db;
        }
        
        public List<Exam> GetExamList()
        {
            return _db.Exams.ToList();
        }

        public Exam FindExam(int id)
        {
            return _db.Exams.Find(id);
        }

        public void SaveExam(Exam exam)
        {
            _db.Entry(exam).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void AddExam(Exam exam)
        {
            _db.Exams.Add(exam);
            _db.SaveChanges();
        }

        public void DeleteExam(int id)
        {
            Exam exam = FindExam(id);

            _db.Exams.Remove(exam);
            _db.SaveChanges();
        }

        public void DisposeDb()
        {
            _db.Dispose();
        }
    }
}