import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletephoneComponent } from './deletephone.component';

describe('DeletephoneComponent', () => {
  let component: DeletephoneComponent;
  let fixture: ComponentFixture<DeletephoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeletephoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletephoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
