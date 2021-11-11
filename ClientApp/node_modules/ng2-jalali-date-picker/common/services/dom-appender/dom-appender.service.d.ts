import { TDrops, TOpens } from '../../types/poistions.type';
export declare class DomHelper {
    private static setYAxisPosition(element, container, anchor, drops);
    private static setXAxisPosition(element, container, anchor, dimElem, opens);
    private static isTopInView(el);
    private static isBottomInView(el);
    private static isLeftInView(el);
    private static isRightInView(el);
    appendElementToPosition(config: IAppendToArgs): void;
    setElementPosition({element, container, anchor, dimElem, drops, opens}: IAppendToArgs): void;
}
export interface IAppendToArgs {
    container: HTMLElement;
    element: HTMLElement;
    anchor: HTMLElement;
    dimElem: HTMLElement;
    drops: TDrops;
    opens: TOpens;
}
