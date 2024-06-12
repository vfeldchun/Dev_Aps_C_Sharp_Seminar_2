namespace HW_Seminar2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte bVar = 20;
            int iVar = 66000;
            long lVar = 9999999999;

            var bBits = (Bits)bVar;
            var iBits = (Bits)iVar;
            var lBits = (Bits)lVar;

            // Приведение типов
            bVar = bBits;
            iVar = iBits;
            lVar = lBits;

            Console.WriteLine($"{bVar}, {iVar}, {lVar}");

            lVar = iBits;
            Console.WriteLine(lVar);
            lVar = bBits;
            Console.WriteLine(lVar);
            
            iVar = bBits;
            Console.WriteLine(iVar);
            // Число будет обрезано до размера int
            iVar = lBits;
            Console.WriteLine(iVar);

            // Тут понятно числа будут обрезаны до размера byte
            bVar = iBits;
            Console.WriteLine(bVar);
            bVar = lBits;
            Console.WriteLine(bVar);



        }
    }
}
