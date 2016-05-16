namespace Declarations
{
    public interface ILogger
   {
      void Debug(string debug);
      void Info(string info);
      void Warning(string warn);
      void Error(string error);
   }
}
