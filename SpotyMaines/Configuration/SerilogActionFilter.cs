using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Text.RegularExpressions;

namespace SpotyMaines.Configuration
{
    public class SerilogActionFilter : IActionFilter
    {
        private object endPointName;
        private object ModuleName;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            endPointName = context.RouteData.Values["action"]!
                .ToString()!.SeparetesUpperCases();

            ModuleName = context.RouteData.Values["controller"];

            Log.Logger.Information($"[Módulo de {ModuleName}] -> Tentando {endPointName}...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                Log.Logger.Information($"[Módulo de {ModuleName}] -> {endPointName} executado com sucesso");
            }
            else if (context.Exception != null)
            {
                Log.Logger.Error($"[Módulo de {ModuleName}] -> Falha ao executar {endPointName}");
            }
        }
    }

    public static class StringExtensions
    {
        public static string SeparetesUpperCases(this string nomeMetodo)
        {
            string separetesUpperCases = @"([A-Z][a-z]*)";

            MatchCollection matches = Regex.Matches(nomeMetodo, separetesUpperCases);

            string methodSeparetadName = "";

            foreach (Match m in matches)
                methodSeparetadName += m.Value + " ";

            return methodSeparetadName;
        }
    }
}
