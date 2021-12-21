/*import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  Inject,
  OnDestroy
} from '@angular/core';
import {MatCalendar} from '@angular/material/datepicker';
import {DateAdapter, MAT_DATE_FORMATS, MatDateFormats} from '@angular/material/core';
import {Subject} from 'rxjs';
import {takeUntil} from 'rxjs/operators';

@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class DatepickerComponent {
    fechaHeader = FechaHeader;
  }
  */
  /** Custom header component for datepicker. */
 /* @Component({
    selector: 'appfechaHeader',
    styles: [`
      .fecha-header {
        display: flex;
        align-items: center;
        padding: 0.5em;
      }
  
      .fecha-header-label {
        flex: 1;
        height: 1em;
        font-weight: 500;
        text-align: center;
      }
  
      .fecha-double-arrow .mat-icon {
        margin: -22%;
      }
    `],
    template: `
      <div class="fecha-header">
        <button mat-icon-button class="fecha-double-arrow" (click)="previousClicked('year')">
          <mat-icon>keyboard_arrow_left</mat-icon>
          <mat-icon>keyboard_arrow_left</mat-icon>
        </button>
        <button mat-icon-button (click)="previousClicked('month')">
          <mat-icon>keyboard_arrow_left</mat-icon>
        </button>
        <span class="fecha-header-label">{{periodLabel}}</span>
        <button mat-icon-button (click)="nextClicked('month')">
          <mat-icon>keyboard_arrow_right</mat-icon>
        </button>
        <button mat-icon-button class="fecha-double-arrow" (click)="nextClicked('year')">
          <mat-icon>keyboard_arrow_right</mat-icon>
          <mat-icon>keyboard_arrow_right</mat-icon>
        </button>
      </div>
    `,
    changeDetection: ChangeDetectionStrategy.OnPush,
  })

  export class FechaHeader<D> implements OnDestroy {
    private _destroyed = new Subject<void>();
  
    constructor(
        private _calendar: MatCalendar<D>, private _dateAdapter: DateAdapter<D>,
        @Inject(MAT_DATE_FORMATS) private _dateFormats: MatDateFormats, cdr: ChangeDetectorRef) {
      _calendar.stateChanges
          .pipe(takeUntil(this._destroyed))
          .subscribe(() => cdr.markForCheck());
    }
  
    ngOnDestroy() {
      this._destroyed.next();
      this._destroyed.complete();
    }
  
    get periodLabel() {
      return this._dateAdapter
          .format(this._calendar.activeDate, this._dateFormats.display.monthYearLabel)
          .toLocaleUpperCase();
    }
  
    previousClicked(mode: 'month' | 'year') {
      this._calendar.activeDate = mode === 'month' ?
          this._dateAdapter.addCalendarMonths(this._calendar.activeDate, -1) :
          this._dateAdapter.addCalendarYears(this._calendar.activeDate, -1);
    }
  
    nextClicked(mode: 'month' | 'year') {
      this._calendar.activeDate = mode === 'month' ?
          this._dateAdapter.addCalendarMonths(this._calendar.activeDate, 1) :
          this._dateAdapter.addCalendarYears(this._calendar.activeDate, 1);
    }
  }*/

import {Component} from '@angular/core';

/** @title Basic datepicker */
@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss'],
})
export class DatepickerComponent {}