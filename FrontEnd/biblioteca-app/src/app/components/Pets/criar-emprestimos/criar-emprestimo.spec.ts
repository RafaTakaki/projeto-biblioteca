import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CriarEmprestimoComponent } from './criar-emprestimos';
describe('CriarEmprestimoComponent', () => {
  let component: CriarEmprestimoComponent;
  let fixture: ComponentFixture<CriarEmprestimoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarEmprestimoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarEmprestimoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
