import { Router } from "@angular/router";

/**
 * Configuration class needed in base class.
 * The config is provided to the API client at initialization time.
 * API clients inherit from #AuthorizedApiBase and provide the config.
 */
export class IConfig {
    authenticationToken!: string;
    subscriptionKey!: string;
    router!: Router;
}

export class AuthorizedApiBase {
    private readonly authenticationToken: string;
    private readonly subscriptionKey: string;
    private readonly router: Router;

    protected constructor(config: IConfig) {
        this.authenticationToken = config.authenticationToken;
        this.subscriptionKey = config.subscriptionKey;
        this.router = config.router;
    }

    protected transformOptions = (options: RequestInit): Promise<RequestInit> => {
        options.headers = {
            ...options.headers,
            Authorization: `Bearer ${this.authenticationToken}`,
            'Ocp-Apim-Subscription-Key': this.subscriptionKey
        };
        return Promise.resolve(options);
    }

    protected transformResult<U>(url: string, response: any, processor: (response: any) => U) {
        if (response.status === 401) {
            this.router.navigate(['auth/login']);
        }
        return processor(response);
    }
}
