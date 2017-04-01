import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { TdAnchorComponent } from './td-anchor.component';

@NgModule({
    imports: [
        RouterModule
    ],
    declarations: [
        TdAnchorComponent
    ],
    exports: [
        TdAnchorComponent
    ]
})

export class TableModule { }