using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.DAL
{
    public partial class SiteInitializer
    {
        private void GraphsExams()
        {
            _exams.Add(new Exam
            {
                Id = ++_examCounter,
                Name = "Gráficas",
                Description = 
                "Las gráficas son representaciones visuales que pueden estar asociadas con una fórmula, o bien que están conformadas por infinidad de números.\n" + 
                "Las gráficas nos permiten expresar comportamientos de algo que está presente pero que cambia en el mundo.\n",
                Comments = "Al contestar los siguientes reactivos, considera que el eje horizontal corresponde al eje 'x' y el eje vertical corresponde al eje 'y'.",
                Active = true
            });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquella que pasa por el punto (0,%n)"
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 0 &&", IsCorrect = false, Feedback = "En x=0 se tiene y=0 y en x=n se tiene y=n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& VerticalLine -9 9 -9 9 %n &&", IsCorrect = false, Feedback = "Elige que pasa por (n,0) confundiendo 'x' e 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -1 |2*%n| &&", IsCorrect = false, Feedback = "Elige recta que pasa por (0,2n) y (n,n).", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -3, Maximum = -1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 3 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las sigueintes gráficas de rectas, elige la única que no pasa por el punto (%n,%n)"
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -1 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 1 0 &&", IsCorrect = false, Feedback = "Pasa por (0,0) y (n,n)", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& VerticalLine -9 9 -9 9 %n &&", IsCorrect = false, Feedback = "En x=n 'y' toma todos los valores, en particular y=n", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n &&", IsCorrect = false, Feedback = "En todo 'x' se tiene y=n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -3, Maximum = -1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas de rectas, escoge aquella cuya pendiente es mayor a %n."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |6.0 / 5.0 * %n| 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |5.0 / 6.0 * %n| 0 &&", IsCorrect = false, Feedback = "Pendiente igual a (5/6)n que no es mayor a n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 0 &&", IsCorrect = false, Feedback = "Pendiente igual a n, que no es mayor a n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n + 1.0 / 2.0| &&", IsCorrect = false, Feedback = "Pendiente igual a cero.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 5 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "De las sigueintes gráficas de rectas, escoge aquella cuya pendiente es menor a %n."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n * 3.0 / 4.0| 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& VerticalLine -9 9 -9 9 |%n - 1.0 / 2.0| &&", IsCorrect = false, Feedback = "La pendiente está indefinida.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 0 &&", IsCorrect = false, Feedback = "Su pendiente es n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n * 4.0 / 3.0| 0 &&", IsCorrect = false, Feedback = "Su pendiente es mayor que n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 5 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Elige entre las siguietnes gráficas aquélla que tiene una pendiente negativa."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n / %m| -1 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n / %m| &&", IsCorrect = false, Feedback = "Su pendiente es cero.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n / %m| -1 &&", IsCorrect = false, Feedback = "Su pendiente es positiva.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& VerticalLine -9 9 -9 9 -|%n / %m| &&", IsCorrect = false, Feedback = "Su pendiente está indefinida.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas de rectas, escoge la que es decreciente."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n / %m| 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n / %m| 0 &&", IsCorrect = false, Feedback = "Ésta es creciente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n / %m| &&", IsCorrect = false, Feedback = "No cambian los valores", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n / %m| -2 &&", IsCorrect = false, Feedback = "Ésta es creciente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las sigueintes rectas elige la que manifiesta que cuando 'x' crece entonces 'y' decrece."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n / %m| 3 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n / %m| 3 &&", IsCorrect = false, Feedback = "Aquí 'y' crece cuando 'x' crece.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 3 &&", IsCorrect = false, Feedback = "Aquí 'y' se mantiene igual.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n / %m| &&", IsCorrect = false, Feedback = "Aquí 'y' se mantiene igual, aunque negativa.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquélla que pasa por el punto (-|%n+1|, %n)."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n/(%n+1)| |2*%n| &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n/(%n+1)| %n &&", IsCorrect = false, Feedback = "Confusión de punto con sus coordenadas por separado en los ejes.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |(%n+1)/%n| -|%n+1| &&", IsCorrect = false, Feedback = "Confusión de punto con sus coordenadas por separado y cambio de 'x' por 'y' y viceversa.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |(%n+1)/%n| -|2*(%n+1)| &&", IsCorrect = false, Feedback = "Confusción de 'x' por 'y' y 'y' por 'x' en las coordenadas del punto.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 5 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes rectas, elige la que cumple lo siguiente: cada vez que 'x' aumenta una unidad, 'y' aumenta %n unidades."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 1 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |1.0/%n| 1 &&", IsCorrect = false, Feedback = "Confusión en el rol de x e y. Intercambiado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -%n 1 &&", IsCorrect = false, Feedback = "Interpretación de aumento en 'y' incorrecto.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|1.0/%n| 1 &&", IsCorrect = false, Feedback = "Confusión del rol de 'x' e 'y' y de interpretación del aumento en 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 5 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas escoge aquella que cumple que cada vez que 'y' aumenta una unidad, se tiene que 'x' aumenta %n unidades."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |1.0/%n| 1 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 1 &&", IsCorrect = false, Feedback = "Confusción en rol de 'x' e 'y' intercambiado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |1.0/(%n-1)| 1 &&", IsCorrect = false, Feedback = "En el momento de interpretar aumento de 'x' considera n-1 y no n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n-1| 1 &&", IsCorrect = false, Feedback = "Confusión en el rol de 'x' e 'y' además de considerar el aumento de n-1 y no n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 6 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Escoge la recta cuya pendiente es \\(\\dfrac{%m}{%n}\\)"
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m/%n| 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n/%m| 0 &&", IsCorrect = false, Feedback = "Confusión del rol de x e y intercambiado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n/%m| %n &&", IsCorrect = false, Feedback = "Confusión de números en la pendiente con intersecciones en los ejes cartesianos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| %m &&", IsCorrect = false, Feedback = "Confusión de números en la pendiente con intersecciones con ejes además de intercambio de roles de x e y.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas de rectas, elige aquella cuya pendiente es \\(\\dfrac{1}{%n}\\) y pasa por el punto (0,%n)"
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |1/%n| %n &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n |1/%n| &&", IsCorrect = false, Feedback = "Confusión de pendiente con corte en eje y y viceversa.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n %n &&", IsCorrect = false, Feedback = "Elección considerante solamente el corte con el eje y.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |1/%n| |1/%n| &&", IsCorrect = false, Feedback = "Elección considerando sólamente la pendiente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 6 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguietnes gráficas de rectas, escoge la que tiene una pendiente igual a \\(\\dfrac{-1}{%n}\\) y que pasa por el punto (%n,0)."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|1/%n| 1 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|1/%n| %n &&", IsCorrect = false, Feedback = "Intercambio de rol de x e y en coordenadas del punto (n,0)", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -%n |%n*%n| &&", IsCorrect = false, Feedback = "Interpretación de la pendiente intercambiando el rol de x con y.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -%n %n &&", IsCorrect = false, Feedback = "Intercambio de la x e y en punto y en la interpretación de la pendiente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 6 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas de rectas, elige la que muesta que cada vez que 'x' aumenta %m unidades, la 'y' aumenta %n unidades."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n/%m| 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m/%n| 0 &&", IsCorrect = false, Feedback = "Intercambio de rol en 'x' e 'y'", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| %m &&", IsCorrect = false, Feedback = "Asocia la pendiente con las intersecciones e intercambia el rol de 'x' e 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n/%m| %n &&", IsCorrect = false, Feedback = "Asocia la pendiente con las interseccion con los ejes.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las gráficas de rectas dadas, escoge la recta que cumple que cuando 'x' crece %m unidades, se tiene que 'y' decrece %n unidades."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n/%m| %n &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| %m &&", IsCorrect = false, Feedback = "Intercambio de roles en 'x' e 'y'", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|(1-%n)/%m| -1 &&", IsCorrect = false, Feedback = "Ubicar el punto (m, -n) como si la recta pasara por el origen.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|(1-%n)/%m| 1 &&", IsCorrect = false, Feedback = "Ubicar el punto (m, -n) como si la recta pasara por el origen.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las sigueintes gr[aficas de rectas, escoge aquella que comple que su coordenada 'x' siempre vale lo mismo."
            });
            _options.Add(new QuestionOption { Description = "&& VerticalLine -9 9 -9 9 %n &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n &&", IsCorrect = false, Feedback = "Intercambio de roles en 'x' e 'y'", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 1 0 &&", IsCorrect = false, Feedback = "Interpretar que 'x' siempre valga lo mismo que 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 0 &&", IsCorrect = false, Feedback = "Interpretar que en la recta hay algo constante, su inclinación.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -3, Maximum = -1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Escoge entre las siguientes gráficas de rectas aquella que representa que el valor de 'y' no cambia a pesar de que el de 'x' cambia."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& VerticalLine -9 9 -9 9 %n &&", IsCorrect = false, Feedback = "Intercambio del rol de 'x' e 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 1 0 &&", IsCorrect = false, Feedback = "Interpretar que el valor de 'y' se mantiene igual al de 'x'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 %n 0 &&", IsCorrect = false, Feedback = "Interpretar que lo que no cambia es el valor de la pendiente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -3, Maximum = -1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas debes elegir aquella que satisface la siguiente: con cada cambio en 'x' de una unidad, se tiene un cambio en 'y' de \\(\\dfrac{%m}{\\,\\,%n\\,\\,}\\) unidades."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m/%n| 1 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m*%n| 1 &&", IsCorrect = false, Feedback = "Intercambio de roles de 'x' e 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| 1  &&", IsCorrect = false, Feedback = "Signo que afecta el comportamiento creciente/decreciente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m*%n| 1 &&", IsCorrect = false, Feedback = "Intercambio de roles de 'x' e 'y' y además de signo que afecta el comportamiento creciente/decreciente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 5 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = -1, Maximum = -1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes gráficas escoge la que cumple que cuando x=0, se tiene y=%m y cuando y=0, se tiene que x=%n"
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| %m &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m/%n| %m &&", IsCorrect = false, Feedback = "Error en signo en corte del eje 'x'", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| -%m &&", IsCorrect = false, Feedback = "Error en signo de corte del eje 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m/%n| -%m &&", IsCorrect = false, Feedback = "Error en signo en corte con ejes 'x' e 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -2, Maximum = -2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -4, Maximum = -4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -6, Maximum = -6 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = -1, Maximum = -1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = -3, Maximum = -3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = -5, Maximum = -5 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las sigueintes gráficas, escoge aquélla que cumple que con cada cambio en 'x' de una unidad, se tiene un cambio en 'y' de \\(\\dfrac{%n}{\\,\\,%m\\,\\,}\\) unidades."
            });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%n/%m| 0 &&", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 |%m/%n| 0 &&", IsCorrect = false, Feedback = "Intercambio de roles de 'x' e 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%n/%m| 0 &&", IsCorrect = false, Feedback = "Signo del cambio de 'y' no considerado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "&& Polynomial -9 9 -9 9 -|%m/%n| 0 &&", IsCorrect = false, Feedback = "Intercambio de roles de 'x' e 'y' y falta considerar el signo del cambio de 'y'.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -2, Maximum = -2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -4, Maximum = -4 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
        }
    }
}
