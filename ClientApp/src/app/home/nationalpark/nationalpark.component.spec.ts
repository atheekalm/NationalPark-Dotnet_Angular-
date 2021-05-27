/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NationalparkComponent } from './nationalpark.component';

describe('NationalparkComponent', () => {
  let component: NationalparkComponent;
  let fixture: ComponentFixture<NationalparkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NationalparkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NationalparkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
