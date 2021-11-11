import { Moment } from 'jalali-moment';
import { WeekDays } from '../common/types/week-days.type';
import { UtilsService } from '../common/services/utils/utils.service';
import { IDay } from './day.model';
import { IDayCalendarConfig, IDayCalendarConfigInternal } from './day-calendar-config.model';
import { IMonthCalendarConfig } from '../month-calendar/month-calendar-config';
export declare class DayCalendarService {
    private utilsService;
    private readonly DAYS;
    readonly DEFAULT_CONFIG: IDayCalendarConfig;
    readonly GREGORIAN_CONFIG_EXTENTION: IDayCalendarConfig;
    constructor(utilsService: UtilsService);
    private removeNearMonthWeeks(currentMonth, monthArray);
    getConfig(config: IDayCalendarConfig): IDayCalendarConfigInternal;
    generateDaysMap(firstDayOfWeek: WeekDays): {
        [key: number]: string;
    };
    generateMonthArray(config: IDayCalendarConfigInternal, month: Moment, selected: Moment[]): IDay[][];
    generateWeekdays(firstDayOfWeek: WeekDays, locale?: string): Moment[];
    isDateDisabled(date: Moment, config: IDayCalendarConfigInternal): boolean;
    getHeaderLabel(config: IDayCalendarConfigInternal, month: Moment): string;
    shouldShowLeft(min: Moment, currentMonthView: Moment): boolean;
    shouldShowRight(max: Moment, currentMonthView: Moment): boolean;
    generateDaysIndexMap(firstDayOfWeek: WeekDays): {
        [key: number]: string;
    };
    getMonthCalendarConfig(componentConfig: IDayCalendarConfigInternal): IMonthCalendarConfig;
    getDayBtnText(config: IDayCalendarConfigInternal, day: Moment): string;
    getDayBtnCssClass(config: IDayCalendarConfigInternal, day: Moment): string;
}
