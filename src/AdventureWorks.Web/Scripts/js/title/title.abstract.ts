import { Injectable } from '@angular/core';

@Injectable()
export abstract class TitleService {
    abstract setTitle(title: string): void;
}