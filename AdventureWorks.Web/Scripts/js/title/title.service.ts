import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { TitleService } from './title.interface'

@Injectable()
export class BrowserTitleService implements TitleService {
    constructor(private title : Title) { }

    setTitle(title: string) : void {
        this.title.setTitle(title);
    }
}