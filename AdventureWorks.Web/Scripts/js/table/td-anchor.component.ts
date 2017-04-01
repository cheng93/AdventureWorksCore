import { Component, Input } from '@angular/core';

@Component({
    selector: 'td-anchor,[tdAnchor]',
    templateUrl: './td-anchor.template.html'
})

export class TdAnchorComponent {
    @Input() href: string = "#";
}