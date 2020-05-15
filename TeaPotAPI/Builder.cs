using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using System;
using TeaPotParameters;

namespace TeaPotAPI
{
    public class Builder
    {
        private ksPart iPart;

        //Создание интерфейса эскиза. Используется в нескольких методах, поэтому расположен здесь
        ksEntity iSketch;
        ksSketchDefinition iDefinitionSketch;

        /// <summary>
        /// Сборка всех деталей
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void Build(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        { 
            this.iPart = iPart;
            CreateBody(iPart, teaPotParams);
            CreateSpout(iPart, _kompas, teaPotParams);
            CreateHandle(iPart, _kompas, teaPotParams);
            CreateHandle2(iPart, _kompas, teaPotParams);  
        }

        /// <summary>
        /// Сборка с закрытой ручкой
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void BuildClosed(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            this.iPart = iPart;
            CreateHandleClosed(iPart, _kompas, teaPotParams);
        }

        /// <summary>
        /// Создание корпуса чайника
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void CreateBody(ksPart iPart, TeaPotParams teaPotParams)
        {
            double radius = teaPotParams.TeaPotDiameter/2;
            double height = teaPotParams.TeaPotHeight;
            CreateSketch(out iSketch, out iDefinitionSketch);
            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, 0, radius, 1);
            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();
            int X = Convert.ToInt32(teaPotParams.TeaPotBodyColor);
            ExctrusionSketch(iPart, iSketch, height, true,X);
        }

        /// <summary>
        /// Создание носика чайника
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void CreateSpout(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double theoffset = teaPotParams.TeaPotHeight - 
                (teaPotParams.TeaPotDiameter / 5) * 1.5;
            double theheight = teaPotParams.TeaPotSpoutHeight;
            double thelength = teaPotParams.TeaPotSpoutLength;
            double thewidth = teaPotParams.TeaPotSpoutWidth;
            double parx = (teaPotParams.TeaPotDiameter / 2) - 5;
            double pary = -(teaPotParams.TeaPotDiameter / 10);
            RectangleCreator(iPart, _kompas, 
                teaPotParams, theoffset, 
                theheight, thelength, 
                thewidth, parx, pary);
            Fillet(iPart, 7, teaPotParams.TeaPotSpoutWidth / 2, teaPotParams);                    
        }
       
        /// <summary>
        /// Создание первой части ручки чайника
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void CreateHandle(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double theoffset = teaPotParams.TeaPotHeight - 
                (teaPotParams.TeaPotDiameter / 5) * 1.5;
            double theheight = (teaPotParams.TeaPotDiameter / 5);
            double thelength = 40;
            double thewidth = (teaPotParams.TeaPotDiameter / 5);
            double parx = -(teaPotParams.TeaPotDiameter / 2) - 
                (teaPotParams.TeaPotDiameter / 10) - (thelength / 2);
            double pary = -(teaPotParams.TeaPotDiameter / 10);
            RectangleCreator(iPart, _kompas, 
                teaPotParams, theoffset, 
                theheight, thelength,
                thewidth, parx, pary);
        }

        /// <summary>
        /// Создание закрытой ручки
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void CreateHandleClosed(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double theoffset = teaPotParams.TeaPotHeight - teaPotParams.TeaPotHandleSize;
            double theheight = (teaPotParams.TeaPotDiameter / 5);
            double thelength = 40;
            double thewidth = (teaPotParams.TeaPotDiameter / 5);
            double parx = -(teaPotParams.TeaPotDiameter / 2) - 
                (teaPotParams.TeaPotDiameter/10) - (thelength / 2);
            double pary = -(teaPotParams.TeaPotDiameter / 10);
            RectangleCreator(iPart, _kompas, 
                teaPotParams, theoffset, 
                theheight, thelength, 
                thewidth, parx, pary);
            Fillet(iPart, 10, teaPotParams.TeaPotDiameter / 20, teaPotParams);
            Fillet(iPart, 11, teaPotParams.TeaPotDiameter / 20, teaPotParams);
        }

        /// <summary>
        /// Создание второй части ручки чайника
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        public void CreateHandle2(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double theoffset = teaPotParams.TeaPotHeight - teaPotParams.TeaPotHandleSize;
            double theheight = teaPotParams.TeaPotHeight - theoffset - 
                (teaPotParams.TeaPotDiameter / 10);
            double thelength = (teaPotParams.TeaPotDiameter / 5);
            double thewidth = (teaPotParams.TeaPotDiameter / 5);
            double parx = -(teaPotParams.TeaPotDiameter / 2) - 10 - 
                (teaPotParams.TeaPotDiameter / 5) - 
                (teaPotParams.TeaPotDiameter / 10);
            double pary = -((teaPotParams.TeaPotDiameter / 10));
            RectangleCreator(iPart, _kompas, 
                teaPotParams, theoffset, 
                theheight, thelength, 
                thewidth, parx, pary);
             Fillet(iPart, 10, teaPotParams.TeaPotDiameter / 20, teaPotParams);
             Fillet(iPart, 11, teaPotParams.TeaPotDiameter / 20, teaPotParams);
             Fillet(iPart, 12, 0.1, teaPotParams);
        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="iSketch">Эскиз</param>
        /// <param name="iDefinitionSketch">Определение эскиза</param>
        /// <param name="offset">Смещение от начальной плоскости</param>
        private void CreateSketch(out ksEntity iSketch, 
            out ksSketchDefinition iDefinitionSketch, double offset = 0)
        {
            #region Создание смещенной плоскости -------------------------
            // интерфейс смещенной плоскости
            ksEntity iPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            // Получаем интрефейс настроек смещенной плоскости
            ksPlaneOffsetDefinition iPlaneDefinition = 
                (ksPlaneOffsetDefinition)iPlane.GetDefinition();
            // Настройки : начальная позиция, направление смещения, 
            // расстояние от плоскости, принять все настройки (create)
            iPlaneDefinition.SetPlane(iPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY));
            iPlaneDefinition.direction = true;
            iPlaneDefinition.offset = offset;
            iPlane.Create();
            #endregion --------------------------------------------------
            // Создаем обьект эскиза
            iSketch = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_sketch);
            // Получаем интерфейс настроек эскиза
            iDefinitionSketch = iSketch.GetDefinition();
            // Устанавливаем плоскость эскиза
            iDefinitionSketch.SetPlane(iPlane);
            // Теперь когда св-ва эскиза установлены можно его создать 
            iSketch.Create();
        }

        /// <summary>
        /// Выдавливание по эскизу
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="iSketch">Эскиз</param>
        /// <param name="depth">Глубина выдавливания</param>
        /// <param name="direction">Направление выдавливания</param>
        /// <param name="X">Цвет детали</param>
        private void ExctrusionSketch(ksPart iPart, ksEntity iSketch, 
            double depth, bool direction,int X)
        {
            //Операция выдавливание
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            //Интерфейс операции выдавливания
            ksBossExtrusionDefinition extrusionDef = 
                (ksBossExtrusionDefinition)entityExtr.GetDefinition();
            //Интерфейс структуры параметров выдавливания
            ksExtrusionParam extrProp = (ksExtrusionParam)extrusionDef.ExtrusionParam();
            //Эскиз операции выдавливания
            extrusionDef.SetSketch(iSketch);
            //Направление выдавливания
            if (direction == false)
            {
                extrProp.direction = (short)Direction_Type.dtReverse;
            }
            else
            {
                extrProp.direction = (short)Direction_Type.dtNormal;
            }
            //Тип выдавливания
            extrProp.typeNormal = (short)End_Type.etBlind;
            //Глубина выдавливания
            if (direction == false)
            {
                extrProp.depthReverse = depth;
            }
            else
            {
                extrProp.depthNormal = depth;
            }
            //Установка цвета детали
            entityExtr.SetAdvancedColor(X, 2, 2, 2, 3, 1, 2);
            //Создание операции
            entityExtr.Create();
        }

        /// <summary>
        /// Скругление рёбер объекта
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="index">Индекс грани, рёбра которой необходимо скруглить</param>
        /// <param name="radius">Радиус скругления</param>
        /// <param name="teaPotParams">Параметры детали</param>
        private void Fillet(ksPart iPart, int index, double radius, TeaPotParams teaPotParams)
        {
            // Получение интерфейса объекта скругление
            ksEntity entityFillet = 
                (ksEntity)iPart.NewEntity((int)Obj3dType.o3d_fillet);
            // Получаем интерфейс параметров объекта скругление
            ksFilletDefinition filletDefinition = 
                (ksFilletDefinition)entityFillet.GetDefinition();
            // Радиус скругления 
            filletDefinition.radius = radius;
            // Не продолжать по касательным ребрам
            filletDefinition.tangent = true;
            // Получаем массив граней объекта
            ksEntityCollection entityCollectionPart = 
                (ksEntityCollection)iPart.EntityCollection((int)Obj3dType.o3d_face);
            // Получаем массив скругляемых граней
            ksEntityCollection entityCollectionFillet = 
                (ksEntityCollection)filletDefinition.array();
            entityCollectionFillet.Clear();
            // Заполняем массив скругляемых объектов
            entityCollectionFillet.Add(entityCollectionPart.GetByIndex(index));
            //Перевод выбранного цвета в целочисленный тип данных, чтобы функция смогла опознать цвет
            int X = Convert.ToInt32(teaPotParams.TeaPotHandleColor);
            //Окрашивание скругляемой области, потому что при скруглении у неё сбрасывается цвет
            entityFillet.SetAdvancedColor(X, 2, 2, 2, 2, 1, 2);
            // Создаем скругление
            entityFillet.Create();
        }

        /// <summary>
        /// Создание прямоугольника
        /// </summary>
        /// <param name="iPart">Интерфейс детали</param>
        /// <param name="_kompas">Окно приложения Компас</param>
        /// <param name="teaPotParams">Параметры детали</param>
        /// <param name="theoffset">Смещение от начальной плоскости</param>
        /// <param name="theheight">Высота прямоугольника</param>
        /// <param name="thelength">Длина прямоугольника</param>
        /// <param name="thewidth">Ширина прямоугольника</param>
        /// <param name="parx">Координата X прямоугольника</param>
        /// <param name="pary">Координата Y прямоугольника</param>
        public void RectangleCreator(ksPart iPart, KompasObject _kompas, 
            TeaPotParams teaPotParams, double theoffset, 
            double theheight, double thelength, 
            double thewidth, double parx, double pary)
        {
            double offset = theoffset;
            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            // Построить прямоугольник (x1,y1, x2,y2, style)
            ksRectangleParam par = 
                (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            // Высота прямоугольника
            double height = theheight;
            // Длина прямоугольника
            par.width = thelength;
            // Ширина прямоугольника
            par.height = thewidth; 
            // Координаты X и Y прямоугольника
            par.x = parx;
            par.y = pary;
            // При нуле не видно деталь.
            par.style = 1; 
            iDocument2D.ksRectangle(par);
            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();
            int X = Convert.ToInt32(teaPotParams.TeaPotHandleColor);
            ExctrusionSketch(iPart, iSketch, height, true, X);
        }
    }
}
