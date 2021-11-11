import { ECalendarValue } from '../../types/calendar-value-enum';
import { SingleCalendarValue } from '../../types/single-calendar-value';
import { Moment, unitOfTime } from 'jalali-moment';
import { CalendarValue } from '../../types/calendar-value';
import { IDate } from '../../models/date.model';
import { CalendarMode } from '../../types/calendar-mode';
import { DateValidator } from '../../types/validator.type';
import { ICalendarInternal } from '../../models/calendar.model';
export interface DateLimits {
    minDate?: SingleCalendarValue;
    maxDate?: SingleCalendarValue;
    minTime?: SingleCalendarValue;
    maxTime?: SingleCalendarValue;
}
export declare class UtilsService {
    static debounce(func: Function, wait: number): () => void;
    createArray(size: number): number[];
    convertToMoment(date: SingleCalendarValue, format: string, locale?: string): Moment;
    isDateValid(date: string, format: string, locale?: string): boolean;
    getDefaultDisplayDate(current: Moment, selected: Moment[], allowMultiSelect: boolean, minDate: Moment, locale: string): Moment;
    getInputType(value: CalendarValue, allowMultiSelect: boolean): ECalendarValue;
    convertToMomentArray(value: CalendarValue, format: string, allowMultiSelect: boolean, locale: string): Moment[];
    convertFromMomentArray(format: string, value: Moment[], convertTo: ECalendarValue, locale: string): CalendarValue;
    convertToString(value: CalendarValue, format: string, locale?: string): string;
    clearUndefined<T>(obj: T): T;
    updateSelected(isMultiple: boolean, currentlySelected: Moment[], date: IDate, granularity?: unitOfTime.Base): Moment[];
    closestParent(element: HTMLElement, selector: string): HTMLElement;
    onlyTime(m: Moment): Moment;
    granularityFromType(calendarType: CalendarMode): unitOfTime.Base;
    createValidator({minDate, maxDate, minTime, maxTime}: DateLimits, format: string, calendarType: CalendarMode, locale: string): DateValidator;
    datesStringToStringArray(value: string): string[];
    getValidMomentArray(value: string, format: string, locale: string): Moment[];
    shouldShowCurrent(showGoToCurrent: boolean, mode: CalendarMode, min: Moment, max: Moment): boolean;
    isDateInRange(date: Moment, from: Moment, to: Moment): boolean;
    convertPropsToMoment(obj: {
        [key: string]: any;
    }, format: string, props: string[], locale?: string): void;
    shouldResetCurrentView<T extends ICalendarInternal>(prevConf: T, currentConf: T): boolean;
    getNativeElement(elem: HTMLElement | string): HTMLElement;
}
