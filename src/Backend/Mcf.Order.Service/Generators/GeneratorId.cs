namespace Mcf.Order.Service.Generators
{
    public static class GeneratorId
    {
        private static int id = 0;

        public static int GetNext()
        {
            return ++id > 99 ? 0 : id;
        }
    }
}
