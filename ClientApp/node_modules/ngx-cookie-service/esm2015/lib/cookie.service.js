// This service is based on the `ng2-cookies` package which sadly is not a service and does
// not use `DOCUMENT` injection and therefore doesn't work well with AoT production builds.
// Package: https://github.com/BCJTI/ng2-cookies
import { Injectable, Inject, PLATFORM_ID, InjectionToken } from '@angular/core';
import { DOCUMENT, isPlatformBrowser } from '@angular/common';
import * as i0 from "@angular/core";
import * as i1 from "@angular/common";
export class CookieService {
    constructor(
    // The type `Document` may not be used here. Although a fix is on its way,
    // we will go with `any` for now to support Angular 2.4.x projects.
    // Issue: https://github.com/angular/angular/issues/12631
    // Fix: https://github.com/angular/angular/pull/14894
    document, 
    // Get the `PLATFORM_ID` so we can check if we're in a browser.
    platformId) {
        this.document = document;
        this.platformId = platformId;
        this.documentIsAccessible = isPlatformBrowser(this.platformId);
    }
    /**
     * @param name Cookie name
     * @returns boolean - whether cookie with specified name exists
     */
    check(name) {
        if (!this.documentIsAccessible) {
            return false;
        }
        name = encodeURIComponent(name);
        const regExp = this.getCookieRegExp(name);
        const exists = regExp.test(this.document.cookie);
        return exists;
    }
    /**
     * @param name Cookie name
     * @returns property value
     */
    get(name) {
        if (this.documentIsAccessible && this.check(name)) {
            name = encodeURIComponent(name);
            const regExp = this.getCookieRegExp(name);
            const result = regExp.exec(this.document.cookie);
            return this.safeDecodeURIComponent(result[1]);
        }
        else {
            return '';
        }
    }
    /**
     * @returns all the cookies in json
     */
    getAll() {
        if (!this.documentIsAccessible) {
            return {};
        }
        const cookies = {};
        const document = this.document;
        if (document.cookie && document.cookie !== '') {
            document.cookie.split(';').forEach((currentCookie) => {
                const [cookieName, cookieValue] = currentCookie.split('=');
                cookies[this.safeDecodeURIComponent(cookieName.replace(/^ /, ''))] = this.safeDecodeURIComponent(cookieValue);
            });
        }
        return cookies;
    }
    set(name, value, expiresOrOptions, path, domain, secure, sameSite) {
        if (!this.documentIsAccessible) {
            return;
        }
        if (typeof expiresOrOptions === 'number' || expiresOrOptions instanceof Date || path || domain || secure || sameSite) {
            const optionsBody = {
                expires: expiresOrOptions,
                path,
                domain,
                secure,
                sameSite: sameSite ? sameSite : 'Lax',
            };
            this.set(name, value, optionsBody);
            return;
        }
        let cookieString = encodeURIComponent(name) + '=' + encodeURIComponent(value) + ';';
        const options = expiresOrOptions ? expiresOrOptions : {};
        if (options.expires) {
            if (typeof options.expires === 'number') {
                const dateExpires = new Date(new Date().getTime() + options.expires * 1000 * 60 * 60 * 24);
                cookieString += 'expires=' + dateExpires.toUTCString() + ';';
            }
            else {
                cookieString += 'expires=' + options.expires.toUTCString() + ';';
            }
        }
        if (options.path) {
            cookieString += 'path=' + options.path + ';';
        }
        if (options.domain) {
            cookieString += 'domain=' + options.domain + ';';
        }
        if (options.secure === false && options.sameSite === 'None') {
            options.secure = true;
            console.warn(`[ngx-cookie-service] Cookie ${name} was forced with secure flag because sameSite=None.` +
                `More details : https://github.com/stevermeister/ngx-cookie-service/issues/86#issuecomment-597720130`);
        }
        if (options.secure) {
            cookieString += 'secure;';
        }
        if (!options.sameSite) {
            options.sameSite = 'Lax';
        }
        cookieString += 'sameSite=' + options.sameSite + ';';
        this.document.cookie = cookieString;
    }
    /**
     * @param name   Cookie name
     * @param path   Cookie path
     * @param domain Cookie domain
     */
    delete(name, path, domain, secure, sameSite = 'Lax') {
        if (!this.documentIsAccessible) {
            return;
        }
        const expiresDate = new Date('Thu, 01 Jan 1970 00:00:01 GMT');
        this.set(name, '', { expires: expiresDate, path, domain, secure, sameSite });
    }
    /**
     * @param path   Cookie path
     * @param domain Cookie domain
     */
    deleteAll(path, domain, secure, sameSite = 'Lax') {
        if (!this.documentIsAccessible) {
            return;
        }
        const cookies = this.getAll();
        for (const cookieName in cookies) {
            if (cookies.hasOwnProperty(cookieName)) {
                this.delete(cookieName, path, domain, secure, sameSite);
            }
        }
    }
    /**
     * @param name Cookie name
     * @returns property RegExp
     */
    getCookieRegExp(name) {
        const escapedName = name.replace(/([\[\]\{\}\(\)\|\=\;\+\?\,\.\*\^\$])/gi, '\\$1');
        return new RegExp('(?:^' + escapedName + '|;\\s*' + escapedName + ')=(.*?)(?:;|$)', 'g');
    }
    safeDecodeURIComponent(encodedURIComponent) {
        try {
            return decodeURIComponent(encodedURIComponent);
        }
        catch (_a) {
            // probably it is not uri encoded. return as is
            return encodedURIComponent;
        }
    }
}
CookieService.ɵprov = i0.ɵɵdefineInjectable({ factory: function CookieService_Factory() { return new CookieService(i0.ɵɵinject(i1.DOCUMENT), i0.ɵɵinject(i0.PLATFORM_ID)); }, token: CookieService, providedIn: "root" });
CookieService.decorators = [
    { type: Injectable, args: [{
                providedIn: 'root',
            },] }
];
CookieService.ctorParameters = () => [
    { type: undefined, decorators: [{ type: Inject, args: [DOCUMENT,] }] },
    { type: InjectionToken, decorators: [{ type: Inject, args: [PLATFORM_ID,] }] }
];
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiY29va2llLnNlcnZpY2UuanMiLCJzb3VyY2VSb290IjoiLi4vLi4vLi4vcHJvamVjdHMvbmd4LWNvb2tpZS1zZXJ2aWNlL3NyYy8iLCJzb3VyY2VzIjpbImxpYi9jb29raWUuc2VydmljZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQSwyRkFBMkY7QUFDM0YsMkZBQTJGO0FBQzNGLGdEQUFnRDtBQUVoRCxPQUFPLEVBQUUsVUFBVSxFQUFFLE1BQU0sRUFBRSxXQUFXLEVBQUUsY0FBYyxFQUFFLE1BQU0sZUFBZSxDQUFDO0FBQ2hGLE9BQU8sRUFBRSxRQUFRLEVBQUUsaUJBQWlCLEVBQUUsTUFBTSxpQkFBaUIsQ0FBQzs7O0FBSzlELE1BQU0sT0FBTyxhQUFhO0lBR3hCO0lBQ0UsMEVBQTBFO0lBQzFFLG1FQUFtRTtJQUNuRSx5REFBeUQ7SUFDekQscURBQXFEO0lBQzNCLFFBQWE7SUFDdkMsK0RBQStEO0lBQ2xDLFVBQWtDO1FBRnJDLGFBQVEsR0FBUixRQUFRLENBQUs7UUFFVixlQUFVLEdBQVYsVUFBVSxDQUF3QjtRQUUvRCxJQUFJLENBQUMsb0JBQW9CLEdBQUcsaUJBQWlCLENBQUMsSUFBSSxDQUFDLFVBQVUsQ0FBQyxDQUFDO0lBQ2pFLENBQUM7SUFFRDs7O09BR0c7SUFDSCxLQUFLLENBQUMsSUFBWTtRQUNoQixJQUFJLENBQUMsSUFBSSxDQUFDLG9CQUFvQixFQUFFO1lBQzlCLE9BQU8sS0FBSyxDQUFDO1NBQ2Q7UUFFRCxJQUFJLEdBQUcsa0JBQWtCLENBQUMsSUFBSSxDQUFDLENBQUM7UUFFaEMsTUFBTSxNQUFNLEdBQVcsSUFBSSxDQUFDLGVBQWUsQ0FBQyxJQUFJLENBQUMsQ0FBQztRQUNsRCxNQUFNLE1BQU0sR0FBWSxNQUFNLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxRQUFRLENBQUMsTUFBTSxDQUFDLENBQUM7UUFFMUQsT0FBTyxNQUFNLENBQUM7SUFDaEIsQ0FBQztJQUVEOzs7T0FHRztJQUNILEdBQUcsQ0FBQyxJQUFZO1FB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Q0FTSSxNQUFNLFNBQUMsUUFBUTtZQWRzQixjQUFjLHVCQWdCbkQsTUFBTSxTQUFDLFdBQVciLCJzb3VyY2VzQ29udGVudCI6WyIvLyBUaGlzIHNlcnZpY2UgaXMgYmFzZWQgb24gdGhlIGBuZzItY29va2llc2AgcGFja2FnZSB3aGljaCBzYWRseSBpcyBub3QgYSBzZXJ2aWNlIGFuZCBkb2VzXG4vLyBub3QgdXNlIGBET0NVTUVOVGAgaW5qZWN0aW9uIGFuZCB0aGVyZWZvcmUgZG9lc24ndCB3b3JrIHdlbGwgd2l0aCBBb1QgcHJvZHVjdGlvbiBidWlsZHMuXG4vLyBQYWNrYWdlOiBodHRwczovL2dpdGh1Yi5jb20vQkNKVEkvbmcyLWNvb2tpZXNcblxuaW1wb3J0IHsgSW5qZWN0YWJsZSwgSW5qZWN0LCBQTEFURk9STV9JRCwgSW5qZWN0aW9uVG9rZW4gfSBmcm9tICdAYW5ndWxhci9jb3JlJztcbmltcG9ydCB7IERPQ1VNRU5ULCBpc1BsYXRmb3JtQnJvd3NlciB9IGZyb20gJ0Bhbmd1bGFyL2NvbW1vbic7XG5cbkBJbmplY3RhYmxlKHtcbiAgcHJvdmlkZWRJbjogJ3Jvb3QnLFxufSlcbmV4cG9ydCBjbGFzcyBDb29raWVTZXJ2aWNlIHtcbiAgcHJpdmF0ZSByZWFkb25seSBkb2N1bWVudElzQWNjZXNzaWJsZTogYm9vbGVhbjtcblxuICBjb25zdHJ1Y3RvcihcbiAgICAvLyBUaGUgdHlwZSBgRG9jdW1lbnRgIG1heSBub3QgYmUgdXNlZCBoZXJlLiBBbHRob3VnaCBhIGZpeCBpcyBvbiBpdHMgd2F5LFxuICAgIC8vIHdlIHdpbGwgZ28gd2l0aCBgYW55YCBmb3Igbm93IHRvIHN1cHBvcnQgQW5ndWxhciAyLjQueCBwcm9qZWN0cy5cbiAgICAvLyBJc3N1ZTogaHR0cHM6Ly9naXRodWIuY29tL2FuZ3VsYXIvYW5ndWxhci9pc3N1ZXMvMTI2MzFcbiAgICAvLyBGaXg6IGh0dHBzOi8vZ2l0aHViLmNvbS9hbmd1bGFyL2FuZ3VsYXIvcHVsbC8xNDg5NFxuICAgIEBJbmplY3QoRE9DVU1FTlQpIHByaXZhdGUgZG9jdW1lbnQ6IGFueSxcbiAgICAvLyBHZXQgdGhlIGBQTEFURk9STV9JRGAgc28gd2UgY2FuIGNoZWNrIGlmIHdlJ3JlIGluIGEgYnJvd3Nlci5cbiAgICBASW5qZWN0KFBMQVRGT1JNX0lEKSBwcml2YXRlIHBsYXRmb3JtSWQ6IEluamVjdGlvblRva2VuPG9iamVjdD5cbiAgKSB7XG4gICAgdGhpcy5kb2N1bWVudElzQWNjZXNzaWJsZSA9IGlzUGxhdGZvcm1Ccm93c2VyKHRoaXMucGxhdGZvcm1JZCk7XG4gIH1cblxuICAvKipcbiAgICogQHBhcmFtIG5hbWUgQ29va2llIG5hbWVcbiAgICogQHJldHVybnMgYm9vbGVhbiAtIHdoZXRoZXIgY29va2llIHdpdGggc3BlY2lmaWVkIG5hbWUgZXhpc3RzXG4gICAqL1xuICBjaGVjayhuYW1lOiBzdHJpbmcpOiBib29sZWFuIHtcbiAgICBpZiAoIXRoaXMuZG9jdW1lbnRJc0FjY2Vzc2libGUpIHtcbiAgICAgIHJldHVybiBmYWxzZTtcbiAgICB9XG5cbiAgICBuYW1lID0gZW5jb2RlVVJJQ29tcG9uZW50KG5hbWUpO1xuXG4gICAgY29uc3QgcmVnRXhwOiBSZWdFeHAgPSB0aGlzLmdldENvb2tpZVJlZ0V4cChuYW1lKTtcbiAgICBjb25zdCBleGlzdHM6IGJvb2xlYW4gPSByZWdFeHAudGVzdCh0aGlzLmRvY3VtZW50LmNvb2tpZSk7XG5cbiAgICByZXR1cm4gZXhpc3RzO1xuICB9XG5cbiAgLyoqXG4gICAqIEBwYXJhbSBuYW1lIENvb2tpZSBuYW1lXG4gICAqIEByZXR1cm5zIHByb3BlcnR5IHZhbHVlXG4gICAqL1xuICBnZXQobmFtZTogc3RyaW5nKTogc3RyaW5nIHtcbiAgICBpZiAodGhpcy5kb2N1bWVudElzQWNjZXNzaWJsZSAmJiB0aGlzLmNoZWNrKG5hbWUpKSB7XG4gICAgICBuYW1lID0gZW5jb2RlVVJJQ29tcG9uZW50KG5hbWUpO1xuXG4gICAgICBjb25zdCByZWdFeHA6IFJlZ0V4cCA9IHRoaXMuZ2V0Q29va2llUmVnRXhwKG5hbWUpO1xuICAgICAgY29uc3QgcmVzdWx0OiBSZWdFeHBFeGVjQXJyYXkgPSByZWdFeHAuZXhlYyh0aGlzLmRvY3VtZW50LmNvb2tpZSk7XG5cbiAgICAgIHJldHVybiB0aGlzLnNhZmVEZWNvZGVVUklDb21wb25lbnQocmVzdWx0WzFdKTtcbiAgICB9IGVsc2Uge1xuICAgICAgcmV0dXJuICcnO1xuICAgIH1cbiAgfVxuXG4gIC8qKlxuICAgKiBAcmV0dXJucyBhbGwgdGhlIGNvb2tpZXMgaW4ganNvblxuICAgKi9cbiAgZ2V0QWxsKCk6IHsgW2tleTogc3RyaW5nXTogc3RyaW5nIH0ge1xuICAgIGlmICghdGhpcy5kb2N1bWVudElzQWNjZXNzaWJsZSkge1xuICAgICAgcmV0dXJuIHt9O1xuICAgIH1cblxuICAgIGNvbnN0IGNvb2tpZXM6IHsgW2tleTogc3RyaW5nXTogc3RyaW5nIH0gPSB7fTtcbiAgICBjb25zdCBkb2N1bWVudDogYW55ID0gdGhpcy5kb2N1bWVudDtcblxuICAgIGlmIChkb2N1bWVudC5jb29raWUgJiYgZG9jdW1lbnQuY29va2llICE9PSAnJykge1xuICAgICAgZG9jdW1lbnQuY29va2llLnNwbGl0KCc7JykuZm9yRWFjaCgoY3VycmVudENvb2tpZSkgPT4ge1xuICAgICAgICBjb25zdCBbY29va2llTmFtZSwgY29va2llVmFsdWVdID0gY3VycmVudENvb2tpZS5zcGxpdCgnPScpO1xuICAgICAgICBjb29raWVzW3RoaXMuc2FmZURlY29kZVVSSUNvbXBvbmVudChjb29raWVOYW1lLnJlcGxhY2UoL14gLywgJycpKV0gPSB0aGlzLnNhZmVEZWNvZGVVUklDb21wb25lbnQoY29va2llVmFsdWUpO1xuICAgICAgfSk7XG4gICAgfVxuXG4gICAgcmV0dXJuIGNvb2tpZXM7XG4gIH1cblxuICAvKipcbiAgICogQHBhcmFtIG5hbWUgICAgIENvb2tpZSBuYW1lXG4gICAqIEBwYXJhbSB2YWx1ZSAgICBDb29raWUgdmFsdWVcbiAgICogQHBhcmFtIGV4cGlyZXMgIE51bWJlciBvZiBkYXlzIHVudGlsIHRoZSBjb29raWVzIGV4cGlyZXMgb3IgYW4gYWN0dWFsIGBEYXRlYFxuICAgKiBAcGFyYW0gcGF0aCAgICAgQ29va2llIHBhdGhcbiAgICogQHBhcmFtIGRvbWFpbiAgIENvb2tpZSBkb21haW5cbiAgICogQHBhcmFtIHNlY3VyZSAgIFNlY3VyZSBmbGFnXG4gICAqIEBwYXJhbSBzYW1lU2l0ZSBPV0FTUCBzYW1lc2l0ZSB0b2tlbiBgTGF4YCwgYE5vbmVgLCBvciBgU3RyaWN0YC4gRGVmYXVsdHMgdG8gYExheGBcbiAgICovXG4gIHNldChuYW1lOiBzdHJpbmcsIHZhbHVlOiBzdHJpbmcsIGV4cGlyZXM/OiBudW1iZXIgfCBEYXRlLCBwYXRoPzogc3RyaW5nLCBkb21haW4/OiBzdHJpbmcsIHNlY3VyZT86IGJvb2xlYW4sIHNhbWVTaXRlPzogJ0xheCcgfCAnTm9uZScgfCAnU3RyaWN0Jyk6IHZvaWQ7XG5cbiAgLyoqXG4gICAqIENvb2tpZSdzIHBhcmFtZXRlcnM6XG4gICAqIDxwcmU+XG4gICAqIGV4cGlyZXMgIE51bWJlciBvZiBkYXlzIHVudGlsIHRoZSBjb29raWVzIGV4cGlyZXMgb3IgYW4gYWN0dWFsIGBEYXRlYFxuICAgKiBwYXRoICAgICBDb29raWUgcGF0aFxuICAgKiBkb21haW4gICBDb29raWUgZG9tYWluXG4gICAqIHNlY3VyZSAgIFNlY3VyZSBmbGFnXG4gICAqIHNhbWVTaXRlIE9XQVNQIHNhbWVzaXRlIHRva2VuIGBMYXhgLCBgTm9uZWAsIG9yIGBTdHJpY3RgLiBEZWZhdWx0cyB0byBgTGF4YFxuICAgKiA8L3ByZT5cbiAgICogQHBhcmFtIG5hbWUgICAgIENvb2tpZSBuYW1lXG4gICAqIEBwYXJhbSB2YWx1ZSAgICBDb29raWUgdmFsdWVcbiAgICogQHBhcmFtIG9wdGlvbnMgIEJvZHkgd2l0aCBjb29raWUncyBwYXJhbXNcbiAgICovXG4gIHNldChcbiAgICBuYW1lOiBzdHJpbmcsXG4gICAgdmFsdWU6IHN0cmluZyxcbiAgICBvcHRpb25zPzoge1xuICAgICAgZXhwaXJlcz86IG51bWJlciB8IERhdGU7XG4gICAgICBwYXRoPzogc3RyaW5nO1xuICAgICAgZG9tYWluPzogc3RyaW5nO1xuICAgICAgc2VjdXJlPzogYm9vbGVhbjtcbiAgICAgIHNhbWVTaXRlPzogJ0xheCcgfCAnTm9uZScgfCAnU3RyaWN0JztcbiAgICB9XG4gICk6IHZvaWQ7XG5cbiAgc2V0KFxuICAgIG5hbWU6IHN0cmluZyxcbiAgICB2YWx1ZTogc3RyaW5nLFxuICAgIGV4cGlyZXNPck9wdGlvbnM/OiBudW1iZXIgfCBEYXRlIHwgYW55LFxuICAgIHBhdGg/OiBzdHJpbmcsXG4gICAgZG9tYWluPzogc3RyaW5nLFxuICAgIHNlY3VyZT86IGJvb2xlYW4sXG4gICAgc2FtZVNpdGU/OiAnTGF4JyB8ICdOb25lJyB8ICdTdHJpY3QnXG4gICk6IHZvaWQge1xuICAgIGlmICghdGhpcy5kb2N1bWVudElzQWNjZXNzaWJsZSkge1xuICAgICAgcmV0dXJuO1xuICAgIH1cblxuICAgIGlmICh0eXBlb2YgZXhwaXJlc09yT3B0aW9ucyA9PT0gJ251bWJlcicgfHwgZXhwaXJlc09yT3B0aW9ucyBpbnN0YW5jZW9mIERhdGUgfHwgcGF0aCB8fCBkb21haW4gfHwgc2VjdXJlIHx8IHNhbWVTaXRlKSB7XG4gICAgICBjb25zdCBvcHRpb25zQm9keSA9IHtcbiAgICAgICAgZXhwaXJlczogZXhwaXJlc09yT3B0aW9ucyxcbiAgICAgICAgcGF0aCxcbiAgICAgICAgZG9tYWluLFxuICAgICAgICBzZWN1cmUsXG4gICAgICAgIHNhbWVTaXRlOiBzYW1lU2l0ZSA/IHNhbWVTaXRlIDogJ0xheCcsXG4gICAgICB9O1xuXG4gICAgICB0aGlzLnNldChuYW1lLCB2YWx1ZSwgb3B0aW9uc0JvZHkpO1xuICAgICAgcmV0dXJuO1xuICAgIH1cblxuICAgIGxldCBjb29raWVTdHJpbmc6IHN0cmluZyA9IGVuY29kZVVSSUNvbXBvbmVudChuYW1lKSArICc9JyArIGVuY29kZVVSSUNvbXBvbmVudCh2YWx1ZSkgKyAnOyc7XG5cbiAgICBjb25zdCBvcHRpb25zID0gZXhwaXJlc09yT3B0aW9ucyA/IGV4cGlyZXNPck9wdGlvbnMgOiB7fTtcblxuICAgIGlmIChvcHRpb25zLmV4cGlyZXMpIHtcbiAgICAgIGlmICh0eXBlb2Ygb3B0aW9ucy5leHBpcmVzID09PSAnbnVtYmVyJykge1xuICAgICAgICBjb25zdCBkYXRlRXhwaXJlczogRGF0ZSA9IG5ldyBEYXRlKG5ldyBEYXRlKCkuZ2V0VGltZSgpICsgb3B0aW9ucy5leHBpcmVzICogMTAwMCAqIDYwICogNjAgKiAyNCk7XG5cbiAgICAgICAgY29va2llU3RyaW5nICs9ICdleHBpcmVzPScgKyBkYXRlRXhwaXJlcy50b1VUQ1N0cmluZygpICsgJzsnO1xuICAgICAgfSBlbHNlIHtcbiAgICAgICAgY29va2llU3RyaW5nICs9ICdleHBpcmVzPScgKyBvcHRpb25zLmV4cGlyZXMudG9VVENTdHJpbmcoKSArICc7JztcbiAgICAgIH1cbiAgICB9XG5cbiAgICBpZiAob3B0aW9ucy5wYXRoKSB7XG4gICAgICBjb29raWVTdHJpbmcgKz0gJ3BhdGg9JyArIG9wdGlvbnMucGF0aCArICc7JztcbiAgICB9XG5cbiAgICBpZiAob3B0aW9ucy5kb21haW4pIHtcbiAgICAgIGNvb2tpZVN0cmluZyArPSAnZG9tYWluPScgKyBvcHRpb25zLmRvbWFpbiArICc7JztcbiAgICB9XG5cbiAgICBpZiAob3B0aW9ucy5zZWN1cmUgPT09IGZhbHNlICYmIG9wdGlvbnMuc2FtZVNpdGUgPT09ICdOb25lJykge1xuICAgICAgb3B0aW9ucy5zZWN1cmUgPSB0cnVlO1xuICAgICAgY29uc29sZS53YXJuKFxuICAgICAgICBgW25neC1jb29raWUtc2VydmljZV0gQ29va2llICR7bmFtZX0gd2FzIGZvcmNlZCB3aXRoIHNlY3VyZSBmbGFnIGJlY2F1c2Ugc2FtZVNpdGU9Tm9uZS5gICtcbiAgICAgICAgICBgTW9yZSBkZXRhaWxzIDogaHR0cHM6Ly9naXRodWIuY29tL3N0ZXZlcm1laXN0ZXIvbmd4LWNvb2tpZS1zZXJ2aWNlL2lzc3Vlcy84NiNpc3N1ZWNvbW1lbnQtNTk3NzIwMTMwYFxuICAgICAgKTtcbiAgICB9XG4gICAgaWYgKG9wdGlvbnMuc2VjdXJlKSB7XG4gICAgICBjb29raWVTdHJpbmcgKz0gJ3NlY3VyZTsnO1xuICAgIH1cblxuICAgIGlmICghb3B0aW9ucy5zYW1lU2l0ZSkge1xuICAgICAgb3B0aW9ucy5zYW1lU2l0ZSA9ICdMYXgnO1xuICAgIH1cblxuICAgIGNvb2tpZVN0cmluZyArPSAnc2FtZVNpdGU9JyArIG9wdGlvbnMuc2FtZVNpdGUgKyAnOyc7XG5cbiAgICB0aGlzLmRvY3VtZW50LmNvb2tpZSA9IGNvb2tpZVN0cmluZztcbiAgfVxuXG4gIC8qKlxuICAgKiBAcGFyYW0gbmFtZSAgIENvb2tpZSBuYW1lXG4gICAqIEBwYXJhbSBwYXRoICAgQ29va2llIHBhdGhcbiAgICogQHBhcmFtIGRvbWFpbiBDb29raWUgZG9tYWluXG4gICAqL1xuICBkZWxldGUobmFtZTogc3RyaW5nLCBwYXRoPzogc3RyaW5nLCBkb21haW4/OiBzdHJpbmcsIHNlY3VyZT86IGJvb2xlYW4sIHNhbWVTaXRlOiAnTGF4JyB8ICdOb25lJyB8ICdTdHJpY3QnID0gJ0xheCcpOiB2b2lkIHtcbiAgICBpZiAoIXRoaXMuZG9jdW1lbnRJc0FjY2Vzc2libGUpIHtcbiAgICAgIHJldHVybjtcbiAgICB9XG4gICAgY29uc3QgZXhwaXJlc0RhdGUgPSBuZXcgRGF0ZSgnVGh1LCAwMSBKYW4gMTk3MCAwMDowMDowMSBHTVQnKTtcbiAgICB0aGlzLnNldChuYW1lLCAnJywgeyBleHBpcmVzOiBleHBpcmVzRGF0ZSwgcGF0aCwgZG9tYWluLCBzZWN1cmUsIHNhbWVTaXRlIH0pO1xuICB9XG5cbiAgLyoqXG4gICAqIEBwYXJhbSBwYXRoICAgQ29va2llIHBhdGhcbiAgICogQHBhcmFtIGRvbWFpbiBDb29raWUgZG9tYWluXG4gICAqL1xuICBkZWxldGVBbGwocGF0aD86IHN0cmluZywgZG9tYWluPzogc3RyaW5nLCBzZWN1cmU/OiBib29sZWFuLCBzYW1lU2l0ZTogJ0xheCcgfCAnTm9uZScgfCAnU3RyaWN0JyA9ICdMYXgnKTogdm9pZCB7XG4gICAgaWYgKCF0aGlzLmRvY3VtZW50SXNBY2Nlc3NpYmxlKSB7XG4gICAgICByZXR1cm47XG4gICAgfVxuXG4gICAgY29uc3QgY29va2llczogYW55ID0gdGhpcy5nZXRBbGwoKTtcblxuICAgIGZvciAoY29uc3QgY29va2llTmFtZSBpbiBjb29raWVzKSB7XG4gICAgICBpZiAoY29va2llcy5oYXNPd25Qcm9wZXJ0eShjb29raWVOYW1lKSkge1xuICAgICAgICB0aGlzLmRlbGV0ZShjb29raWVOYW1lLCBwYXRoLCBkb21haW4sIHNlY3VyZSwgc2FtZVNpdGUpO1xuICAgICAgfVxuICAgIH1cbiAgfVxuXG4gIC8qKlxuICAgKiBAcGFyYW0gbmFtZSBDb29raWUgbmFtZVxuICAgKiBAcmV0dXJucyBwcm9wZXJ0eSBSZWdFeHBcbiAgICovXG4gIHByaXZhdGUgZ2V0Q29va2llUmVnRXhwKG5hbWU6IHN0cmluZyk6IFJlZ0V4cCB7XG4gICAgY29uc3QgZXNjYXBlZE5hbWU6IHN0cmluZyA9IG5hbWUucmVwbGFjZSgvKFtcXFtcXF1cXHtcXH1cXChcXClcXHxcXD1cXDtcXCtcXD9cXCxcXC5cXCpcXF5cXCRdKS9naSwgJ1xcXFwkMScpO1xuXG4gICAgcmV0dXJuIG5ldyBSZWdFeHAoJyg/Ol4nICsgZXNjYXBlZE5hbWUgKyAnfDtcXFxccyonICsgZXNjYXBlZE5hbWUgKyAnKT0oLio/KSg/Ojt8JCknLCAnZycpO1xuICB9XG5cbiAgcHJpdmF0ZSBzYWZlRGVjb2RlVVJJQ29tcG9uZW50KGVuY29kZWRVUklDb21wb25lbnQ6IHN0cmluZyk6IHN0cmluZyB7XG4gICAgdHJ5IHtcbiAgICAgIHJldHVybiBkZWNvZGVVUklDb21wb25lbnQoZW5jb2RlZFVSSUNvbXBvbmVudCk7XG4gICAgfSBjYXRjaCB7XG4gICAgICAvLyBwcm9iYWJseSBpdCBpcyBub3QgdXJpIGVuY29kZWQuIHJldHVybiBhcyBpc1xuICAgICAgcmV0dXJuIGVuY29kZWRVUklDb21wb25lbnQ7XG4gICAgfVxuICB9XG59XG4iXX0=