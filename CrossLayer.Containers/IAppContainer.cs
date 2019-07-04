﻿using BoDi;

namespace CrossLayer.Containers
{
    public interface IAppContainer
    {
        void RegisterAPIs(IObjectContainer objectContainer);

        void RegisterAppiumAndroid(IObjectContainer objectContainer);
    }
}
