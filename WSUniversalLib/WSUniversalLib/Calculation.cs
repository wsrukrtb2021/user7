using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        //массив данных
        static double[] array_Product = { 1.1f, 2.5f, 8.43f };
        static double[] array_Material = { 1.003f, 1.0012f };

        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            //если в качестве параметров метода будут приходить несуществующие типы продукции / материалов, то возвращается значение -1
            if (productType > 3 || productType <= 0 || materialType > 2 || materialType <= 0)
                return -1;
            //если кол-во или ширина или длина меньше или равно 0 , то возвращается значение -1
            if (count <=0 || width <=0 || length <=0)
                return -1;
            //если все условия удовлетворяют
            return Convert.ToInt32(Math.Ceiling(array_Product[productType - 1]) * array_Material[materialType - 1] * count * width * length);
        }
    }
}
