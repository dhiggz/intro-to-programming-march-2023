describe('The Support Page', () => {
  describe('The Help And Support Contact Information', () => {
    beforeEach(() => {
      cy.intercept(
        {
          method: 'GET',
          url: 'http://localhost:1338/oncalldeveloper',
        },
        {
          statusCode: 200,
          body: {
            name: 'Bob Smith',
            phone: '888-8888',
            email: 'bob@compuserve.com',
          },
        }
      );
      cy.visit('/support');
    });

    it('has the support component displayed', () => {
      cy.get('[data-testid="contact-info"]').should('exist');
    });
    it('has the contact name', () => {
      cy.get('[data-testid="contact-info"]')
        .find('[data-testid="name"]')
        .should('contain.text', 'Bob Smith');
    });
    it('has the contact phone', () => {
      cy.get('[data-testid="contact-info"]')
        .find('[data-testid="phone"]')
        .should('contain.text', '888-8888');
    });

    it('has the contact email', () => {
      cy.get('[data-testid="contact-info"]')
        .find('[data-testid="email"]')
        .should('contain.text', 'bob@compuserve.com');
    });
  });
});
