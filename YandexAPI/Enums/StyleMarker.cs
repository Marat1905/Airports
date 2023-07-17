using System;
using System.Collections.Generic;
using System.Text;

namespace YandexAPI.Enums
{
    /// <summary> Стили меток </summary>
    public enum StyleMarker
    {
        /// <summary> </summary>
        pm,
        /// <summary>Метка с хвостиком. Нужно составлять цвет и контент</summary>
        pm2,
        /// <summary>Флаг</summary>
        flag,
        /// <summary>Кнопка</summary>
        vk,
        /// <summary>Голубая метка с хвостиком</summary>
        org,
        /// <summary>Голубая метка с кругом в центре</summary>
        comma,
        /// <summary>Голубая метка в виде круга</summary>
        round,
        /// <summary>Значок дома</summary>
        home,
        /// <summary>Значок работы</summary>
        work,
        /// <summary>Значок с логотипом Яндекса. </summary>
        ya_ru,
    }
}
