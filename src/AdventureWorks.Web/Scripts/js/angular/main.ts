﻿import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';

import '../../css/site.css';

if (process.env.NODE_ENV == 'production') {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule);