using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using System;

namespace TeaPot
{
    class Builder
    {
        public ksPart iPart;

        public void Build(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            this.iPart = iPart;
            CreateBody(iPart, _kompas, teaPotParams);
            CreateSpout(iPart, _kompas, teaPotParams);
            CreateHandle(iPart, _kompas, teaPotParams);
        }
        public void CreateBody(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double radius = teaPotParams.TeaPotDiameter/2;
            double height = teaPotParams.TeaPotHeight;
            ksEntity iSketch;

            ksSketchDefinition iDefinitionSketch;

            CreateSketch(out iSketch, out iDefinitionSketch);

            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
            iDocument2D.ksCircle(0, 0, radius, 1);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();
            int X = Convert.ToInt32(teaPotParams.TeaPotBodyColor);
            ExctrusionSketch(iPart, iSketch, height, true,X);
        }

        public void CreateSpout(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double spout = (teaPotParams.TeaPotDiameter / 5);
            double offset = teaPotParams.TeaPotHeight - spout*1.5;
            double width = spout; // spoutWidth
            double height = spout; // spoutHeigth

            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;
            CreateSketch(out iSketch, out iDefinitionSketch,offset);
            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            // Построить прямоугольник (x1,y1, x2,y2, style)
            ksRectangleParam par1 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par1.x = (teaPotParams.TeaPotDiameter/2)-5;
            par1.height = width; // spoutWidth.
            par1.y = - (par1.height/2);
            par1.width = teaPotParams.TeaPotSpoutLength ; //spoutLength
            
            par1.style = 1; // При нуле не видно деталь.
            iDocument2D.ksRectangle(par1);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();
            int X = Convert.ToInt32(teaPotParams.TeaPotHandleColor);
            ExctrusionSketch(iPart, iSketch, height , true,X);
            Fillet(iPart, 7, width/2, teaPotParams);
        }

        public void CreateHandle(ksPart iPart, KompasObject _kompas, TeaPotParams teaPotParams)
        {
            double spout = (teaPotParams.TeaPotDiameter / 5);
            double offset = teaPotParams.TeaPotHeight - spout * 1.5; // Offset
            double width = spout; // spoutWidth
            double height = spout; // spoutHeigth

            ksEntity iSketch;
            ksSketchDefinition iDefinitionSketch;
            CreateSketch(out iSketch, out iDefinitionSketch, offset);
            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();

            // Построить прямоугольник (x1,y1, x2,y2, style)
            ksRectangleParam par2 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par2.width = 40; //spoutLength
            par2.height = width; // spoutWidth.
            par2.x = -(teaPotParams.TeaPotDiameter/2)-10-(par2.width/2);
            par2.y = -(par2.height / 2);
            

            par2.style = 1; // При нуле не видно деталь.
            iDocument2D.ksRectangle(par2);

            // Закончить редактировать эскиз
            iDefinitionSketch.EndEdit();
            int X = Convert.ToInt32(teaPotParams.TeaPotHandleColor);
            ExctrusionSketch(iPart, iSketch, height, true,X);

            //PART 2
            double offset2 = teaPotParams.TeaPotHeight-teaPotParams.TeaPotHandleSize; // Offset 25
            double width2 = spout; // spoutWidth
            double height2 = teaPotParams.TeaPotHeight - offset2 - spout/2; // spoutHeigth

            ksEntity iSketch2;
            ksSketchDefinition iDefinitionSketch2;
            CreateSketch(out iSketch2, out iDefinitionSketch2, offset2);
            // Интерфейс для рисования = на скетче;
            ksDocument2D iDocument2D2 = (ksDocument2D)iDefinitionSketch2.BeginEdit();

            // Построить прямоугольник (x1,y1, x2,y2, style)
            ksRectangleParam par3 = (ksRectangleParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            par3.width = spout; //spoutLength
            par3.height = width2; // spoutWidth.
            par3.x = -(teaPotParams.TeaPotDiameter / 2) - 10-par3.width-(par3.width/2);
            par3.y = -(par3.height / 2);


            par3.style = 1; // При нуле не видно деталь.
            iDocument2D2.ksRectangle(par3);

            // Закончить редактировать эскиз
            iDefinitionSketch2.EndEdit();
            int X1 = Convert.ToInt32(teaPotParams.TeaPotHandleColor);
            ExctrusionSketch(iPart, iSketch2, height2, true,X1);
            Fillet(iPart, 10, spout/4, teaPotParams);
            Fillet(iPart, 11, spout/4, teaPotParams);
            Fillet(iPart, 12, 0.1, teaPotParams);
            Fillet(iPart, 13, spout/2, teaPotParams);
            Fillet(iPart, 14, spout/2, teaPotParams);
        }

        /// <summary>
        /// Создать эскиз
        /// </summary>
        /// <param name="iSketch">Эскиз</param>
        /// <param name="iDefinitionSketch">Определение эскиза</param>
        /// <param name="offset">Смещение от начальной плоскости</param>
        private void CreateSketch(out ksEntity iSketch, out ksSketchDefinition iDefinitionSketch, double offset = 0)
        {
            #region Создание смещенную плоскость -------------------------
            // интерфейс смещенной плоскости
            ksEntity iPlane = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_planeOffset);

            // Получаем интрефейс настроек смещенной плоскости
            ksPlaneOffsetDefinition iPlaneDefinition = (ksPlaneOffsetDefinition)iPlane.GetDefinition();

            // Настройки : начальная позиция, направление смещения, расстояние от плоскости, принять все настройки (create)
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
        private void ExctrusionSketch(ksPart iPart, ksEntity iSketch, double depth, bool direction,int X)
        {
            //Операция выдавливание
            ksEntity entityExtr = (ksEntity)iPart.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            //Интерфейс операции выдавливания
            ksBossExtrusionDefinition extrusionDef = (ksBossExtrusionDefinition)entityExtr.GetDefinition();
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
            //Создание операции ???
            //Colors(X);
            entityExtr.SetAdvancedColor(X, 2, 2, 2, 3, 1, 2);
            entityExtr.Create();
        }

        public void Fillet(ksPart iPart, int index, double radius, TeaPotParams teaPotParams)
        {
            // Получение интерфейса объекта скругление
            ksEntity entityFillet = (ksEntity)iPart.NewEntity((int)Obj3dType.o3d_fillet);
            // Получаем интерфейс параметров объекта скругление
            ksFilletDefinition filletDefinition = (ksFilletDefinition)entityFillet.GetDefinition();
            // Радиус скругления 
            filletDefinition.radius = radius;
            // Не продолжать по касательным ребрам
            filletDefinition.tangent = true;
            // Получаем массив граней объекта
            ksEntityCollection entityCollectionPart = (ksEntityCollection)iPart.EntityCollection((int)Obj3dType.o3d_face);
            // Получаем массив скругляемых граней
            ksEntityCollection entityCollectionFillet = (ksEntityCollection)filletDefinition.array();
            entityCollectionFillet.Clear();

            //ksEntity ENT = entityCollectionFillet.GetByIndex(0);

            // Заполняем массив скругляемых объектов
            entityCollectionFillet.Add(entityCollectionPart.GetByIndex(index));

            // Создаем скругление
            int X = Convert.ToInt32(teaPotParams.TeaPotHandleColor);
            entityFillet.SetAdvancedColor(X, 2, 2, 2, 2, 1, 2);
            entityFillet.Create();
            
        }
    }
}
