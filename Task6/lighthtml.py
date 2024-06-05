# Клас LightNode - базовий клас для елементів розмітки
class LightNode:
    pass

# Дочірній клас LightTextNode для текстових елементів
class LightTextNode(LightNode):
    def __init__(self, text):
        self.text = text

    def outerHTML(self):
        return self.text

# Дочірній клас LightElementNode для елементів з тегами
class LightElementNode(LightNode):
    def __init__(self, tag_name, display_type, closing_type, css_classes=None):
        self.tag_name = tag_name
        self.display_type = display_type
        self.closing_type = closing_type
        self.css_classes = css_classes if css_classes is not None else []
        self.children = []

    def add_child(self, child):
        self.children.append(child)

    def outerHTML(self):
        attributes = ' '.join([f'{key}="{value}"' for key, value in self.__dict__.items() if key != 'children'])
        children_html = ''.join([child.outerHTML() for child in self.children])
        if self.closing_type == 'single':
            return f'<{self.tag_name} {attributes}/>'
        else:
            return f'<{self.tag_name} {attributes}>{children_html}</{self.tag_name}>'

    def innerHTML(self):
        return ''.join([child.outerHTML() for child in self.children])
