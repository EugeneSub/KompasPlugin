using System;
using Kompas6API5;
using Kompas6Constants3D;
using TeaPotParameters;

namespace TeaPotAPI
{
    public class KompasConnector
    {
        // Выбор определенного окна приложения компас
        public KompasObject kompas { get; set; }
        // Создание 3Д документа для построения предметов
        private ksDocument3D _doc3D;
        // Управление над интерфейсом программы
        public ksPart iPart { get; set; }

        /// <summary>
        /// Запуск Kompas 3D
        /// </summary>
        /// <param name="teaPotParams"></param>
        public KompasConnector(TeaPotParams teaPotParams)
        {
            TakeKompas();
        }

        /// <summary>
        /// Функция запуска Kompas 3D
        /// </summary>
        public void TakeKompas()
        {
            // Если окно Компаса 3D не включено - создать обьект Компаса 3D
            if (kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(t);
            }
            // Показать Компас 3D          
            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            // Присвоение управления документами _doc3D
            _doc3D = (ksDocument3D)kompas.Document3D();
            // Создание документа
            _doc3D.Create(false, true);
            // Получение интерфейса детали
            iPart = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
        }
    }
}
