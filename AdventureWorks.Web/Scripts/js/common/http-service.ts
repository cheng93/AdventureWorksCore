import { Location } from '@angular/common';

export abstract class HttpService {
    constructor(private location: Location) { }

    protected getEndPoint(endpoint : string) {
        return this.location.prepareExternalUrl(endpoint);
    }
}